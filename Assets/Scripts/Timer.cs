using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int playtime = 0;
    int sec = 0;
    int min = 0;

    int addMinLabel = 0;

    [SerializeField]
    private Text displayTime;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("playTimer");
        Update();
    }

    private IEnumerator playTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
            sec = playtime % 60;
            min = (playtime / 60) % 60;
        }
    }

    void Update()
    {
        if ((sec == 59)||(addMinLabel==1))
        {
            displayTime.text = min.ToString() + " min " + sec.ToString() + " sec";
            addMinLabel = 1;
        }
        else
        {
            displayTime.text = sec.ToString() + " sec";
        }
    }
}
