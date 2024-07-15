using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private float score = 0f;

    [SerializeField]
    private int levelSpawnedNotes = 30;

    private int spawnCounter;

    [SerializeField]
    private NoteSpawner[] noteSpawners;

    [SerializeField]
    private AudioClip musicSoundClip;

    [SerializeField]
    private NoteSpawner noteSpawnerUpPrefab;

    [SerializeField]
    private NoteSpawner noteSpawnerDownPrefab;

    private NoteController[] notesInTheScene;

    [SerializeField]
    private UnityEvent onLevelCompleteEvent;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        spawnCounter = levelSpawnedNotes;
    }

    public void Pause()
    {
        for (int i = 0; i < noteSpawners.Length; ++i)
        {
            noteSpawners[i].StopSpawning();
        }

        notesInTheScene = FindObjectsOfType<NoteController>();

        for (int i = 0; i < notesInTheScene.Length; ++i)
        {
            notesInTheScene[i].StopMoving();
        }
    }

    public void Unpause()
    {
        for (int i = 0; i < noteSpawners.Length; ++i)
        {
            noteSpawners[i].StartSpawning();
        }

        for (int i = 0; i < notesInTheScene.Length; ++i)
        {
            notesInTheScene[i].ContinueMoving();
        }
    }

    public void AddScore(float noteValue)
    {
        // adding the score and making sure it can´t be lower than 0
        score += noteValue;

        if (score < 0f)
        {
            score = 0f;
        }

        // can't go past 100
        if (score > 100f)
        {
            score = 100f;
        }

        UiManager.Instance.UpdateScoreUi(score);
    }

    public void SpawnedNotesCounter()
    {
        spawnCounter -= 1;

        if (spawnCounter == 0)
        {
            onLevelCompleteEvent.Invoke();
        }
    }
}
