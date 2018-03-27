using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabController : MonoBehaviour {
    [SerializeField]
    Button nameBtn;
    [SerializeField]
    Button dessertBtn;
    [SerializeField]
    Button trickBtn;

    [SerializeField]
    GameObject namePane;
    [SerializeField]
    GameObject dessertPane;
    [SerializeField]
    GameObject trickPane;

    public void nameBtnClicked()
    {
        namePane.gameObject.SetActive(true);
        dessertPane.gameObject.SetActive(false);
        trickPane.gameObject.SetActive(false);
        //Debug.Log("nameBtn clicked");
    }

    public void dessertBtnClicked()
    {
        namePane.gameObject.SetActive(false);
        dessertPane.gameObject.SetActive(true);
        trickPane.gameObject.SetActive(false);
        //Debug.Log("dessertBtn clicked");
    }

    public void trickBtnClicked()
    {
        namePane.gameObject.SetActive(false);
        dessertPane.gameObject.SetActive(false);
        trickPane.gameObject.SetActive(true);
        //Debug.Log("trickBtn clicked");
    }
}
