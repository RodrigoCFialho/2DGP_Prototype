using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    private float verticalMoveAmount = 30f;

    [SerializeField]
    private float moveTime = 0.1f;

    [Range(0f, 2f), SerializeField]
    private float scaleAmount = 1.1f;

    private Vector3 initialPosition;
    private Vector3 initialScale;

    [SerializeField]
    private ButtonSelectionManager buttonSelectionManager;

    private void Start()
    {
        initialPosition = transform.position;
        initialScale = transform.localScale;
    }

    private IEnumerator MoveButton(bool startingAnimation)
    {
        Vector3 endPosition;
        Vector3 endScale;

        float elapsedTime = 0f;
        while(elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;

            if (startingAnimation)
            {
                endPosition = initialPosition + new Vector3(0f, verticalMoveAmount, 0f);
                endScale = initialScale * scaleAmount;
            }

            else
            {
                endPosition = initialPosition;
                endScale = initialScale;
            }

            //Calculate the lerped amounts
            Vector3 lerpedPosition = Vector3.Lerp(transform.position, endPosition, (elapsedTime / moveTime));
            Vector3 lerpedScale = Vector3.Lerp(transform.localScale, endScale, (elapsedTime / moveTime));

            //Apply the changes to the position and scale 
            transform.position = lerpedPosition;
            transform.localScale = lerpedScale;

            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Select the button
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Deselect the button
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        StartCoroutine(MoveButton(true));

        buttonSelectionManager.LastSelected = gameObject;

        for (int i = 0; i < buttonSelectionManager.Buttons.Length; i++)
        {
            if (buttonSelectionManager.Buttons[i] == gameObject)
            {
                buttonSelectionManager.LastSelectedIndex = i;
                return;
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StartCoroutine(MoveButton(false));
    }
}
