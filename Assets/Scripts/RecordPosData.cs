using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecordPosData : MonoBehaviour {

	public string fileNamePos;  
	public string fileNameRot; 

	public bool completed = false;
	public bool finished = false;
	public float saveInterval = 0.1f; // save positions each 0.1 second
	public float startTime = 0.1f; // sampling starts at this time


	private List<Vector3> positions;
	private List<Vector3> rotations;

	void OnLevelWasLoaded(int level) {

	

		fileNamePos = "H:/Documents/ProjectDataCapture/positions"+level+".txt" ; // Add level number to file pathname for pos
		fileNameRot = "H:/Documents/ProjectDataCapture/rotations"+level+".txt"; // Add level number to file pathname for rot
	}

	public void Start(){

		Debug.Log ("Start");

		OnLevelWasLoaded (Application.loadedLevel);
		positions = new List<Vector3>(); // initialize the position array
		rotations = new List<Vector3>(); // initialize the rotation array
		// start recording at startTime
		InvokeRepeating("RecPoint", startTime, saveInterval);
	}
	
	void RecPoint(){
		positions.Add(transform.position); // store position
		rotations.Add(transform.rotation.eulerAngles); // store rotation
	}
	
	// function that saves to a text file:
	void SaveToFile(string fileNamePos, string fileNameRot){

			
			if (!finished) {

						Debug.Log ("Saving");

						System.IO.File.WriteAllText (fileNamePos, ""); // clear old file, if any
						foreach (Vector3 pos in positions) {
								// format XYZ separated by ; and with 2 decimal places:
								string line = System.String.Format ("{0,3:f2};{1,3:f2};{2,3:f2}\r\n", pos.x, pos.y, pos.z);
								System.IO.File.AppendAllText (fileNamePos, line); // append to the file
								finished = true;
						}
				
						System.IO.File.WriteAllText (fileNameRot, ""); // clear old file, if any
						foreach (Vector3 rot in rotations) {
								// format XYZ separated by ; and with 2 decimal places:
								string line = System.String.Format ("{0,3:f2};{1,3:f2};{2,3:f2}\r\n", rot.x, rot.y, rot.z);
								System.IO.File.AppendAllText (fileNameRot, line); // append to the file
								finished = true;
						}

				}
	}

	 public void StopRec() {

		Debug.Log ("StopRec");

		CancelInvoke("RecPoint"); // stop recording
		SaveToFile(fileNamePos, fileNameRot); // save positions

	}

	void OnApplicationQuit(){

		if (completed == false) {

			Debug.Log ("OnAppQuit");
			StopRec();

		}


	}
}
