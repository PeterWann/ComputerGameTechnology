using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("hoverOn");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("hoverOff");
    }
}
