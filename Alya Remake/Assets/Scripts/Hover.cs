using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public UnityEvent onHover;
    public UnityEvent onClick;

    //Detect cursor hover
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        onHover?.Invoke();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        onClick?.Invoke();
    }
}
