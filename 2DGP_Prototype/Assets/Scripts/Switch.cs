using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject levelUI = null;

    private void Start()
    {
        levelUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionSystem>().SetInteractible(this);

            levelUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionSystem>().SetInteractible(null);

            levelUI.SetActive(false);
        }
    }

    public void Interact()
    {
        GameManager.Instance.TurnOnLevel();
    }
}
