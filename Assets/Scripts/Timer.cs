using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public Timer time;

	public bool startTime = false;
	public float timer = 0.0f;
	public bool timeFinished = false;
	GameObject h;


	// Use this for initialization
	void Start () {

				startTime = true;
				timeFinished = false;

				if (Application.loadedLevel == 1) {

						h = GameObject.Find ("Main Camera");

				} else {

						h = GameObject.Find ("Controller");

				}
		}
	// TIMER counting UP

	void Update()
	{
		if (startTime == true){

			timer += Time.deltaTime;

			RecordPosData recScript = h.GetComponent<RecordPosData>();
			timeFinished = recScript.finished;
		
			if (timeFinished == true)
			{
				Debug.Log("Finishing Time: "+timer);
			
				// reset timer
				startTime = false;
				timer = 0;
			}
		}
	}

	void OnApplicationQuit(){

		if (timeFinished == false) {

			Debug.Log ("Finishing Time: " + timer);
		
			// reset timer
			startTime = false;
			timer = 0;
		}
	}
}
