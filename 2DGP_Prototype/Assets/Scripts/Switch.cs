using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractible
{
    private GameManager gameManager = null;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionSystem>().SetInteractible(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionSystem>().SetInteractible(null);
        }
    }

    public void Interact()
    {
        gameManager.TurnOnLevel();
    }
}
