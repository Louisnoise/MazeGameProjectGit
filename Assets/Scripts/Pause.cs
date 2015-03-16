using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
	public bool paused = false;
	public GUISkin pauseSkin;
	GameObject g;
	GameObject h;

	void Start(){

		float size = Screen.height * 0.04f;
		pauseSkin.button.fontSize = (int)size;
		g = GameObject.Find ("Controller");
		h = GameObject.FindGameObjectWithTag ("MainCamera");

	}
	
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
				
				Debug.Log ("Pause");
				paused = togglePause ();

		}
	}

	void OnGUI()
	{
		GUI.skin = pauseSkin;
		
		if (paused == true) {
			
			GUI.Box(new Rect ((Screen.width/10), (Screen.height/10), (Screen.width * 0.8f),(Screen.height * 0.8f)),"");	
			GUI.Label(new Rect (15,15,100,100),"Pause");
			int i = Application.loadedLevel;

			if (GUI.Button (new Rect ((Screen.width/2) - (Screen.width * 0.1f), (Screen.height/2) + (Screen.height * 0.05f), Screen.width * 0.2f, Screen.height * 0.1f), "Resume")) {

				Debug.Log ("Resume");
				paused = false;
				togglePause();
				ControlManager(true);
				
			}

			if (GUI.Button (new Rect ((Screen.width/2) - (Screen.width * 0.1f), (Screen.height/2) + (Screen.height * 0.12f), Screen.width * 0.2f, Screen.height * 0.1f), "Next Level")) {

				Debug.Log ("NextLevel");
				if (Application.loadedLevel == 1) {
					
					RecordPosData recScript = h.GetComponent<RecordPosData> ();
					recScript.StopRec ();
					togglePause();
					ControlManager(true);
					Application.LoadLevel(i+1);

				}
				
				else {
					RecordPosData recScript = g.GetComponent<RecordPosData> ();
					recScript.StopRec ();
					togglePause();
					ControlManager(true);
					Application.LoadLevel(i+1);
					
				}

			}
				

			
			if (GUI.Button (new Rect ((Screen.width/2) - (Screen.width * 0.1f), (Screen.height/2) + (Screen.height * 0.2f), Screen.width * 0.2f, Screen.height * 0.1f), "Quit")) {

				Debug.Log ("PauseQuit");
				if (Application.loadedLevel == 1) {
					
					RecordPosData recScript = h.GetComponent<RecordPosData> ();
					recScript.StopRec ();
					togglePause();
					ControlManager(true);
					Application.LoadLevel(0);
				}
				
				else {
					RecordPosData recScript = g.GetComponent<RecordPosData> ();
					recScript.StopRec ();
					togglePause();
					ControlManager(true);
					Application.LoadLevel(0);
					
				}

			}
		}
	}
	
	bool togglePause()
	{
		if (Time.timeScale == 0f) {
				Time.timeScale = 1f;
				ControlManager(true);
				return(false);
		} 

		else {
				Time.timeScale = 0f;
				ControlManager(false);
				return(true); 
		}
	}


	public void ControlManager(bool active){
			
		if (active == true) {
			Debug.Log ("active true");
			if (Application.loadedLevel == 3) {
				
				
				g.GetComponent<MouseLook> ().enabled = true;
				g.GetComponent<FPSInputController> ().enabled = true;
				h.GetComponent<AutoCam> ().enabled = true;
				h.GetComponent<ProtectCameraFromWallClip> ().enabled = true;
				g.GetComponent<CharacterMotor> ().enabled = true;
				
			} 
			
			if (Application.loadedLevel == 2){
				
				g.GetComponent<CharacterMotor> ().enabled = true;
				
			}
			
			if (Application.loadedLevel == 1) {
				
				g.GetComponent<MouseLook> ().enabled = true;
				h.GetComponent<MouseLook> ().enabled = true;
				g.GetComponent<CharacterMotor> ().enabled = true;
				
			}

		}
		else {
			Debug.Log ("active false");

			if (Application.loadedLevel == 3) {
				
				
				g.GetComponent<MouseLook> ().enabled = false;
				g.GetComponent<FPSInputController> ().enabled = false;
				h.GetComponent<AutoCam> ().enabled = false;
				h.GetComponent<ProtectCameraFromWallClip> ().enabled = false;
				g.GetComponent<CharacterMotor> ().enabled = false;
				
			} 
			
			if (Application.loadedLevel == 2){
				
				g.GetComponent<CharacterMotor> ().enabled = false;
				
			}
			
			if (Application.loadedLevel == 1) {
				
				g.GetComponent<MouseLook> ().enabled = false;
				h.GetComponent<MouseLook> ().enabled = false;
				g.GetComponent<CharacterMotor> ().enabled = false;
				
			}
		}
	}


			
}


