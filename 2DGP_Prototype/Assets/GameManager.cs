using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject RhythmGameEnabler = null;

    [SerializeField]
    private NoteController NoteController = null;

    private bool startGame = false;

    private void Start()
    {
        RhythmGameEnabler.SetActive(false);
    }

    private void Update()
    {
        if (!startGame && Input.GetKeyDown(KeyCode.E))
        {
            startGame = true;

            RhythmGameEnabler.SetActive(true);
            NoteController.Move();
        }
    }
}
