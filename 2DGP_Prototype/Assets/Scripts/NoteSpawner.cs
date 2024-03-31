using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField]
    private NoteController notePrefab = null;

    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private float timeBetweenSpawns = 2f;

    private IEnumerator SpawnNotes()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(timeBetweenSpawns);
        for (int i = 0; i >= 0; ++i)
        {
            yield return timetoWait;
            SpawnNote();
        }
    }

    public void StartSpawner()
    {
        StartCoroutine(SpawnNotes());
    }

    private void SpawnNote()
    {
        NoteController noteController = Instantiate(notePrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
