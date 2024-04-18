using System.Collections;
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

    // UI note hit feedback
    [SerializeField]
    private GameObject goodText = null;

    private bool isGoodTextActive = true;

    [SerializeField]
    private GameObject perfectText = null;

    private bool isPerfectTextActive = true;

    [SerializeField]
    private GameObject missText = null;

    private bool isMissTextActive = true;

    [SerializeField]
    private float uiTime = 2f;

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
        DisableGoodText();
        DisablePerfectText();
        DisableMissText();
        // mudar o alpha (esparguete style)
        star1.color = lowAlphaColor;
        star2.color = lowAlphaColor;
        star3.color = lowAlphaColor;

        UpdateScore();
    }

    public void EnableGoodText()
    {
        if (!isGoodTextActive)
        {
            goodText.SetActive(true);
            isGoodTextActive = true;
            StartCoroutine(GoodUiTimer());
        }
        else
        {
            StopCoroutine(GoodUiTimer());
            StartCoroutine(GoodUiTimer());
        }
    }

    private IEnumerator GoodUiTimer()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(uiTime);

        while (true)
        {
            yield return timetoWait;

            DisableGoodText();
            break;
        }
    }

    private void DisableGoodText()
    {
        goodText.SetActive(false);
        isGoodTextActive = false;
    }

    public void EnablePerfectText()
    {
        if (!isPerfectTextActive)
        {
            perfectText.SetActive(true);
            isPerfectTextActive = true;
            StartCoroutine(PerfectUiTimer());
        }
        else
        {
            StopCoroutine(PerfectUiTimer());
            StartCoroutine(PerfectUiTimer());
        }
    }

    private IEnumerator PerfectUiTimer()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(uiTime);

        while (true)
        {
            yield return timetoWait;

            DisablePerfectText();
            break;
        }
    }

    private void DisablePerfectText()
    {
        perfectText.SetActive(false);
        isPerfectTextActive = false;
    }

    public void EnableMissText()
    {
        if (!isMissTextActive)
        {
            missText.SetActive(true);
            isMissTextActive = true;
            StartCoroutine(MissUiTimer());
        }
        else
        {
            StopCoroutine(MissUiTimer());
            StartCoroutine(MissUiTimer());
        }
    }

    private IEnumerator MissUiTimer()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(uiTime);

        while (true)
        {
            yield return timetoWait;

            DisableMissText();
            break;
        }
    }

    private void DisableMissText()
    {
        missText.SetActive(false);
        isMissTextActive = false;
    }

    private void UpdateScore()
    {
        scoreText.text = score + "%";

        UpdateScoreUi();
    }

    public void AddScore(float noteValue)
    {
        // adding the score (can't go past 100)
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
        // Activating the stars' initial colors
        if (star1Value <= score && score < star2Value)
        {
            star1.color = initialColor;
        }
        else if (score < star3Value)
        {
            star2.color = initialColor;
        }
        else
        {
            star3.color = initialColor;
        }

        // Deactivating the stars' initial colors to the low alpha variants
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
