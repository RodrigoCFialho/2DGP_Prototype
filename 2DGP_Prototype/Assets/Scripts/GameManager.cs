using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private float score = 0f;

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
            score = score + noteValue;
        }

        // can't go past 100
        if (score > 100f)
        {
            score = 100f;
        }

        UiManager.Instance.UpdateScoreUi(score);
    }
}
