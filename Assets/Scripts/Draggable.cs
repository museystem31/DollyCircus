using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;

    Transform startParent;
    Vector3 startPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //Debug.Log("dragged from " + startParent.name);

        GetComponent<LayoutElement>().ignoreLayout = true;
        itemBeingDragged.transform.SetParent(transform.parent.parent.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        bool dropPlaceIsSlot = (transform.parent.name.Contains("Slot")) || (transform.parent.name.Contains("slot"));

        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

        if (!dropPlaceIsSlot)
        {
            transform.SetParent(startParent);
        }

        GetComponent<LayoutElement>().ignoreLayout = false;
        GetComponent<CanvasGroup>().blocksRaycasts = true;


    }

}