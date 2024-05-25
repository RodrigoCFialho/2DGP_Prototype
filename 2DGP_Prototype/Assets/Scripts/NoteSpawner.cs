using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField]
    private NoteController notePrefab = null;

    [SerializeField]
    private Transform spawnPoint = null;

    [SerializeField]
    private int maxNotesSpawned = 2;

    [SerializeField]
    private float timeBetweenSpawns = 1f;

    [SerializeField]
    private float spawnWaitTime = 3f;

    [SerializeField]
    private AudioClip soundFXSoundClip;

    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(spawnWaitTime);
        for (int i = 0; i >= 0; ++i)
        {
            yield return timetoWait;
            StartCoroutine(SpawnNotes());
        }
    }

    private IEnumerator SpawnNotes()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(timeBetweenSpawns);
        NotesSpawned();
        for (int i = 0; i < NotesSpawned(); ++i)
        {
            yield return timetoWait;
            GameManager.Instance.SpawnedNotesCounter();
            SpawnNote();
        }
    }

    private int NotesSpawned()
    {
        return Random.Range(1, maxNotesSpawned + 1);
    }

    private void SpawnNote()
    {
        NoteController noteController = Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
        SoundFXManager.Instance.PlaySoundFXClip(soundFXSoundClip, transform, 1f);
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}
