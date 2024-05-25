using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
        spawnCounter = levelSpawnedNotes;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }

    public void AddScore(float noteValue)
    {
        // adding the score and making sure it can´t be lower than 0
        if (score >= -noteValue)
        {
            score += noteValue;
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
            for (int i = 0; i < noteSpawners.Length; ++i)
            {
                noteSpawners[i].Dismiss();
            }
        }

        print(spawnCounter);
    }
}
