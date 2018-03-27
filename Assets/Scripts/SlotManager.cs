using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SlotManager : MonoBehaviour, IDropHandler
{
    string itemCategory;
    string slotCategory;

    string[] desserts = { "macaron", "tart", "waffle", "brownie", "cheese", "shortbread" };
    string[] names = { "eve", "venie", "liuwen", "muhua", "elita", "cecile" };
    string[] tricks = { "unicycle", "ballet", "taming", "dart", "swing", "tightrope" };

    public AudioClip dropSound;
    public AudioClip errorSound;

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        string itemName = Draggable.itemBeingDragged.name;


        if ((!item) && getItemCategory(itemName).Equals(getSlotCategory(transform.name)))
        {

            //Debug.Log("transform is " + transform.name);
            //Debug.Log("Dragged item was placed into " + transform.name);
            Draggable.itemBeingDragged.transform.SetParent(transform);
            SoundManager.instance.playSingle("effectSource",dropSound);

        }
        else
        {
            Debug.Log("wrong category.");
            SoundManager.instance.playSingle("effectSource", errorSound);
        }
    }

    string getSlotCategory(string name)
    {
        if (transform.name.Contains("dessert") || transform.name.Contains("Dessert") ||
            transform.parent.name.Contains("dessert") || transform.parent.name.Contains("Dessert"))
        {
            return "dessert";
        }
        else if (transform.name.Contains("name") || transform.name.Contains("Name") ||
           transform.parent.name.Contains("name") || transform.parent.name.Contains("Name"))
        {
            return "name";
        }
        else
        {
            return "trick";
        }
    }

    string getItemCategory(string itemName)
    {
        for (int i = 0; i < desserts.Length; i++)
        {
            if (itemName == desserts[i])
            {
                return "dessert";
            }
        }

        for (int i = 0; i < names.Length; i++)
        {
            if (itemName == names[i])
            {
                return "name";
            }
        }
        for (int i = 0; i < tricks.Length; i++)
        {
            if (itemName == tricks[i])
            {
                return "trick";
            }
        }
        return "";
    }

}

