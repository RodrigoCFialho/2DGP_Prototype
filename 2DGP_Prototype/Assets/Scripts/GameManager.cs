using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    private bool startGame = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        TurnOffLevel();
    }

    // isto é para apagar, pq é suposto sair do nível pelo pause menu
    private void Update()
    {
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
    }
    
    // Desligar o jogo de ritmo e voltar para o level map
    private void TurnOffLevel()
    {
        startGame = false;

        RhythmGameEnabler.SetActive(false);
        RhythmGameUiEnabler.SetActive(false);
        Player.SetActive(true);
        CogwheelUi.SetActive(true);
    }

    public void Pause()
    {

    }
}
