using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioSource effectSource;
    public AudioSource dubSource;

    public static SoundManager instance = null;
    public GameObject muteBtn;
    private static bool themePlayingState;
    public GameObject muteText;
    public GameObject playText;

    // Use this for initialization
    void Awake()
    {
        themePlayingState = true;
        muteText.SetActive(true);
        playText.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void playSingle(string audioSource, AudioClip sound)
    {
        if (audioSource == "effectSource")
        {
            effectSource.clip = sound;
            effectSource.Play();
            //Debug.Log("is playing some sound!");
        }else
        {
            dubSource.clip = sound;
            dubSource.Play();
        }
    }

    public void muteBtnClick()
    {
        if (themePlayingState)
        {
            GetComponent<AudioSource>().volume = 0;
            themePlayingState = false;
            playText.SetActive(true);
            muteText.SetActive(false);
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.4f;
            themePlayingState = true;
            playText.SetActive(false);
            muteText.SetActive(true);

        }
    }
}
