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
    private float[] timeBetweenSpawns = null;

    private void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(Random.Range(timeBetweenSpawns[0], timeBetweenSpawns[1]));
        for (int i = 0; i >= 0; ++i)
        {
            yield return timetoWait;
            SpawnNote();
            timetoWait = new WaitForSeconds(Random.Range(timeBetweenSpawns[0], timeBetweenSpawns[1]));
        }
    }

    private void SpawnNote()
    {
        NoteController noteController = Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
