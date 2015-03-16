using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUISkin gSkin;
	public Texture MenuScreen;

	void Start(){
		float size = Screen.height * 0.04f;
		gSkin.button.fontSize = (int)size;
	}

	void OnGUI(){
		GUI.skin = gSkin;

		GUI.Box(new Rect (0, 0, Screen.width, Screen.height),"");

		if (GUI.Button (new Rect ((Screen.width/2) - (Screen.width * 0.1f), (Screen.height/2) + (Screen.height * 0.05f), Screen.width * 0.2f, Screen.height * 0.1f), "Start")) {
			
			Application.LoadLevel(1);
			
		}
		
		if (GUI.Button (new Rect ((Screen.width/2) - (Screen.width * 0.1f), (Screen.height/2) + (Screen.height * 0.2f), Screen.width * 0.2f, Screen.height * 0.1f), "Quit")) {
			
			Application.Quit();
		}
	}
}
