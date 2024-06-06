using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelectionManager : MonoBehaviour
{
    public GameObject[] Buttons;

    public GameObject LastSelected {  get; set; }

    public int LastSelectedIndex { get; set; }

    private void OnEnable()
    {
        StartCoroutine(SetSelectedAfterOneFrame());
    }

    private void Update()
    {
        //if we move down
        if (InputManager.instance.NavigationInput.y > 0)
        {
            //Select next button
            HandleNextButtonSelection(1);
        }

        //if we move up
        if (InputManager.instance.NavigationInput.y < 0)
        {
            //Select prior button
            HandleNextButtonSelection(-1);
        }
    }

    private IEnumerator SetSelectedAfterOneFrame()
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(Buttons[0]);
    }

    private void HandleNextButtonSelection(int addition)
    {
        if (EventSystem.current.currentSelectedGameObject == null && LastSelected != null)
        {
            int newIndex = LastSelectedIndex + addition;
            newIndex = Mathf.Clamp(newIndex, 0, Buttons.Length - 1);
            EventSystem.current.SetSelectedGameObject(Buttons[newIndex]);
        }
    }
}
