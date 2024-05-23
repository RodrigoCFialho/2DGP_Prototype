using System.Collections;
using TMPro;
using Unity.VisualScripting;
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

    // estrelas adquiridas
    [SerializeField]
    private Image[] star;

    [SerializeField]
    private float star1Value = 60f;

    [SerializeField]
    private float star2Value = 75f;

    [SerializeField]
    private float star3Value = 90f;

    [SerializeField]
    private Sprite starDeactivated;

    [SerializeField]
    private Sprite starActivated;

    private Coroutine myCoroutine;

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
        DisableGoodText();
        DisablePerfectText();
        DisableMissText();

        for (int i = 0; i < star.Length; ++i)   
        {
            star[i].sprite = starDeactivated;
        }

        UpdateScoreUi(0f);
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
            else if (isPerfectTextActive)
            {
                DisablePerfectText() ;
            }
            else if (isMissTextActive)
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
            myCoroutine = StartCoroutine(UiTimer());
        }
        else
        {
            StopCoroutine(myCoroutine);
            myCoroutine = StartCoroutine(UiTimer());
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
            myCoroutine = StartCoroutine(UiTimer());
        }
        else
        {
            StopCoroutine(myCoroutine);
            myCoroutine = StartCoroutine(UiTimer());
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
            myCoroutine = StartCoroutine(UiTimer());
        }
        else
        {
            StopCoroutine(myCoroutine);
            myCoroutine = StartCoroutine(UiTimer());
        }
    }

    private void DisableMissText()
    {
        feedbackText.gameObject.SetActive(false);
        isMissTextActive = false;
    }

    public void UpdateScoreUi(float score)
    {
        //Updating score text
        scoreText.text = score + "%";

        // Activating the stars' initial colors
        if (star1Value <= score && score < star2Value && star[0].sprite == starDeactivated)
        {
            star[0].sprite = starActivated;
        }
        else if (score < star3Value && star[1].sprite == starDeactivated)
        {
            star[1].sprite = starActivated;
        }
        else if (star[2].sprite == starDeactivated)
        {
            star[2].sprite = starActivated;
        }

        // Deactivating the stars' initial colors to the low alpha variants
        if (score < star1Value && star[0].sprite == starActivated)
        {
            star[0].sprite = starDeactivated;
        }
        if (score < star2Value && star[1].sprite == starActivated)
        {
            star[1].sprite = starDeactivated;
        }
        if (score < star3Value && star[2].sprite == starActivated)
        {
            star[2].sprite = starDeactivated;
        }
    }
}
