using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance {  get; private set; }

    // UI com percentagem de notas acertadas
    [SerializeField]
    private TextMeshProUGUI scoreText = null;

    // UI note hit feedback
    [SerializeField]
    private TextMeshProUGUI feedbackText = null;

    private bool isGoodTextActive = true;

    private bool isPerfectTextActive = true;

    private bool isMissTextActive = true;

    [SerializeField]
    private float uiTime = 2f;

    [SerializeField]
    private float score = 0f;

    // estrelas adquiridas
    [SerializeField]
    private Image[] star;

    [SerializeField]
    private float star1Value = 60f;

    [SerializeField]
    private float star2Value = 75f;

    [SerializeField]
    private float star3Value = 90f;

    private Color lowAlphaColor = new Color(255f, 255f, 255f, 0.5f);

    private Color initialColor;


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

        initialColor = star[0].color;
    }


    private void Start()
    {
        DisableGoodText();
        DisablePerfectText();
        DisableMissText();

        // mudar o alpha
        for (int i = 0; i < star.Length; ++i)
        {
            star[i].color = lowAlphaColor;
        }

        UpdateScore();
    }

    private IEnumerator UiTimer()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(uiTime);

        while (true)
        {
            yield return timetoWait;

            if (isGoodTextActive)
            {
                DisableGoodText();
            }

            if (isPerfectTextActive)
            {
                DisablePerfectText() ;
            }

            if (isMissTextActive)
            {
                DisableMissText();
            }
            
            break;
        }
    }

    public void EnableGoodText()
    {
        if (!isGoodTextActive)
        {
            feedbackText.gameObject.SetActive(true);
            isGoodTextActive = true;
            feedbackText.text = "GOOD";
            StartCoroutine(UiTimer());
        }
        else
        {
            StopCoroutine(UiTimer());
            StartCoroutine(UiTimer());
        }
    }

    private void DisableGoodText()
    {
        feedbackText.gameObject.SetActive(false);
        isGoodTextActive = false;
    }

    public void EnablePerfectText()
    {
        if (!isPerfectTextActive)
        {
            feedbackText.gameObject.SetActive(true);
            isPerfectTextActive = true;
            feedbackText.text = "PERFECT";
            StartCoroutine(UiTimer());
        }
        else
        {
            StopCoroutine(UiTimer());
            StartCoroutine(UiTimer());
        }
    }

    private void DisablePerfectText()
    {
        feedbackText.gameObject.SetActive(false);
        isPerfectTextActive = false;
    }

    public void EnableMissText()
    {
        if (!isMissTextActive)
        {
            feedbackText.gameObject.SetActive(true);
            isMissTextActive = true;
            feedbackText.text = "MISS";
            StartCoroutine(UiTimer());
        }
        else
        {
            StopCoroutine(UiTimer());
            StartCoroutine(UiTimer());
        }
    }

    private void DisableMissText()
    {
        feedbackText.gameObject.SetActive(false);
        isMissTextActive = false;
    }

    private void UpdateScore()
    {
        scoreText.text = score + "%";

        UpdateScoreUi();
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

        UpdateScore();
    }

    private void UpdateScoreUi()
    {
        // Activating the stars' initial colors
        if (star1Value <= score && score < star2Value && star[0].color == lowAlphaColor)
        {
            star[0].color = initialColor;
        }
        else if (score < star3Value && star[1].color == lowAlphaColor)
        {
            star[1].color = initialColor;
        }
        else if (star[2].color == lowAlphaColor)
        {
            star[2].color = initialColor;
        }

        // Deactivating the stars' initial colors to the low alpha variants
        if (score < star1Value && star[0].color == initialColor)
        {
            star[0].color = lowAlphaColor;
        }

        if (score < star2Value && star[1].color == initialColor)
        {
            star[1].color = lowAlphaColor;
        }

        if (score < star3Value && star[2].color == initialColor)
        {
            star[2].color = lowAlphaColor;
        }
    }

}
