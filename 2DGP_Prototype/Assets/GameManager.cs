using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject RhythmGameEnabler = null;

    [SerializeField]
    private GameObject Player = null;

    [SerializeField]
    private NoteSpawner NoteSpawner = null;

    private bool startGame = false;

    private void Start()
    {
        RhythmGameEnabler.SetActive(false);
        Player.SetActive(true);
        startGame = false;
    }

    private void Update()
    {
        if (!startGame && Input.GetKeyDown(KeyCode.E))
        {
            startGame = true;

            RhythmGameEnabler.SetActive(true);
            Player.SetActive(false);
            NoteSpawner.StartSpawner();
        }

        if (startGame && Input.GetKeyDown(KeyCode.R))
        {
            startGame = false;

            RhythmGameEnabler.SetActive(false);
            Player.SetActive(true);
        }
    }
}
