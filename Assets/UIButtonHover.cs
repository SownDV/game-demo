using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverHighlight;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverHighlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverHighlight.SetActive(false);
    }
}
