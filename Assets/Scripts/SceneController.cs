using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour {


    public void startGame()
    {
        //float fadeTime = GameObject.Find("MenuManager").GetComponent<Fader>().BeginFade(1);
        SceneManager.LoadScene("GameScene");
        
    }

    public void goToStoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void goToSecondScene()
    {
        SceneManager.LoadScene("SecondGameScene");
    }
}
