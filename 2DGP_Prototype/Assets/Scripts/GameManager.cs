using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Enablers para ligar e desligar o UI e os objetos do jogo de ritmo
    [SerializeField]
    private GameObject RhythmGameEnabler = null;

    [SerializeField]
    private GameObject RhythmGameUiEnabler = null;


    // UI do level map
    [SerializeField]
    private GameObject CogwheelUi = null;


    [SerializeField]
    private GameObject Player = null;

    [SerializeField]
    private NoteSpawner NoteSpawner = null;

    private bool startGame = false;


    private void Start()
    {
        TurnOffLevel();
    }

    private void Update()
    {
        // Desligar o jogo de ritmo e voltar para o level map
        if (startGame && Input.GetKeyDown(KeyCode.R))
        {
            TurnOffLevel();
        }
    }

    // Iniciar o jogo de ritmo
    public void TurnOnLevel()
    {
        startGame = true;

        RhythmGameEnabler.SetActive(true);
        RhythmGameUiEnabler.SetActive(true);
        Player.SetActive(false);
        CogwheelUi.SetActive(false);
        NoteSpawner.StartSpawner();
    }
    
    private void TurnOffLevel()
    {
        startGame = false;

        RhythmGameEnabler.SetActive(false);
        RhythmGameUiEnabler.SetActive(false);
        Player.SetActive(true);
        CogwheelUi.SetActive(true);
    }
}
