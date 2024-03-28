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


    // estrelas adquiridas (era para fazer em array mas isto não tava a dar ns pq)
    [SerializeField]
    private Image star1 = null;

    [SerializeField]
    private Image star2 = null;

    [SerializeField]
    private Image star3 = null;

    private Color lowAlphaColor = new Color(255f, 255f, 255f, 0.5f);


    private void Start()
    {
        // mudar o alpha esparguete style
        star1.color = lowAlphaColor;
        star2.color = lowAlphaColor;
        star3.color = lowAlphaColor;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "100%";
    }

}
