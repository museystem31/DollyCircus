using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadingSpeed = 0.8f;

    private int drawDepth= -1000;
    private float alpha = 1.0f;
    private int fadingDir = -1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        alpha += fadingDir * fadingSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction) {
        fadingDir = direction;
        return fadingSpeed;
    }
    void sceneLoaded()
    {
        BeginFade(-1);
    }
}
