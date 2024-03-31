using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // UI com percentagem de notas acertadas
    [SerializeField]
    private TextMeshProUGUI scoreText = null;

    [SerializeField]
    private float score = 0f;


    // estrelas adquiridas (era para fazer em array mas isto não tava a dar ns pq)
    [SerializeField]
    private Image star1 = null;

    [SerializeField]
    private float star1Value = 60f;

    [SerializeField]
    private Image star2 = null;

    [SerializeField]
    private float star2Value = 75f;

    [SerializeField]
    private Image star3 = null;

    [SerializeField]
    private float star3Value = 90f;

    private Color lowAlphaColor = new Color(255f, 255f, 255f, 0.5f);

    private Color initialColor;

    private void Awake()
    {
        initialColor = star1.color;
    }


    private void Start()
    {
        // mudar o alpha (esparguete style)
        star1.color = lowAlphaColor;
        star2.color = lowAlphaColor;
        star3.color = lowAlphaColor;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score + "%";

        UpdateScoreUi();
    }

    public void AddScore(float noteValue)
    {
        if (score >= -noteValue)
        {
            score = score + noteValue;
        }
        if (score > 100f)
        {
            score = 100f;
        }

        UpdateScore();
    }

    private void UpdateScoreUi()
    {
        if (star1Value <= score && score < star2Value)
        {
            star1.color = initialColor;
        }
        if (score >= star2Value && score < star3Value)
        {
            star2.color = initialColor;
        }
        if (score >= star3Value)
        {
            star3.color = initialColor;
        }
        if (score < star1Value)
        {
            star1.color = lowAlphaColor;
        }
        if (score < star2Value)
        {
            star2.color = lowAlphaColor;
        }
        if (score < star3Value)
        {
            star3.color = lowAlphaColor;
        }
    }

}
