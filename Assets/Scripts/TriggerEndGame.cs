using UnityEngine;
using System.Collections;

public class TriggerEndGame : MonoBehaviour {

	private bool showFinished;
	public GUISkin finishedSkin;
	public Texture FinishScreen;
	GameObject g;
	GameObject h;

	void Start(){

		float size = Screen.height * 0.04f;
		finishedSkin.button.fontSize = (int)size;

		showFinished = false;

		g = GameObject.Find ("Controller");
		h = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	 void OnTriggerEnter(){

		Debug.Log ("triggerEntered");

		showFinished = true;

		if (Application.loadedLevel == 1) {

						RecordPosData recScript = h.GetComponent<RecordPosData> ();
						recScript.completed = true;
						recScript.StopRec ();
				}

		else {
						RecordPosData recScript = g.GetComponent<RecordPosData> ();
						recScript.completed = true;
						recScript.StopRec ();

				}



	

	}

	void Update(){

		if (showFinished == true) {

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


	void OnGUI(){

		GUI.skin = finishedSkin;

		if (showFinished == true) {

			GUI.Box(new Rect ((Screen.width/10), (Screen.height/10), (Screen.width * 0.8f),(Screen.height * 0.8f)),"");	
			GUI.Label(new Rect (15,15,100,100),"Finished");
			int i = Application.loadedLevel;

			if (GUI.Button (new Rect ((Screen.width/2) - (Screen.width * 0.1f), (Screen.height/2) + (Screen.height * 0.05f), Screen.width * 0.2f, Screen.height * 0.1f), "Next")) {

				Application.LoadLevel(i+1);

			}

			if (GUI.Button (new Rect ((Screen.width/2) - (Screen.width * 0.1f), (Screen.height/2) + (Screen.height * 0.2f), Screen.width * 0.2f, Screen.height * 0.1f), "Quit")) {

				Application.LoadLevel(0);
			}
		}
	}
}
