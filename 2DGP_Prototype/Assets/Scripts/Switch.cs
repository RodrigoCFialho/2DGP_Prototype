using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject levelUI;

    [SerializeField]
    private string levelName;

    [SerializeField]
    private AudioClip soundFXSoundClip;

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
        SoundFXManager.Instance.PlaySoundFXClip(soundFXSoundClip, transform, 1f);

        StartCoroutine(LoadSceneTimer());
    }

    private IEnumerator LoadSceneTimer()
    {
        WaitForSeconds timetoWait = new WaitForSeconds(soundFXSoundClip.length);

        yield return timetoWait;
        SceneManager.LoadScene(levelName);
    }
}
