using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField]
    private NoteController notePrefab = null;

    [SerializeField]
    private Transform spawnPoint = null;

    [SerializeField]
    private float timeBetweenSpawns = 2f;

    private void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(timeBetweenSpawns);
        for (int i = 0; i >= 0; ++i)
        {
            yield return timetoWait;
            SpawnNote();
        }
    }

    private void SpawnNote()
    {
        NoteController noteController = Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
