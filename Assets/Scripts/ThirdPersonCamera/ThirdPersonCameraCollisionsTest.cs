using UnityEngine;
using System.Collections;

public class ThirdPersonCameraCollisions : MonoBehaviour {


	public float distanceAway;
	public float distanceUp;
	public float smooth;
	private Transform follow;
	private Vector3 LookDir;
	private Vector3 targetPosition;



	// Use this for initialization
	void Start () {
	
		follow = GameObject.FindWithTag("Player").transform;
		LookDir = follow.forward;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LateUpdate(){

		Vector3 characterOffset = follow.position + new Vector3(0f, distanceUp/2, 0f);

		LookDir = characterOffset - this.transform.position;
		LookDir.y = 0;
		LookDir.Normalize();

		Debug.DrawRay (this.transform.position, LookDir, Color.green);

		//set target pos
		targetPosition = characterOffset + follow.up * distanceUp - LookDir * distanceAway;

		Debug.DrawLine (follow.position, targetPosition, Color.magenta);
		//smooth transition  = lerp between current pos and target pos * smooth
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

		//looking the right way
		transform.LookAt (follow);

		WallCollision (characterOffset, ref targetPosition);
	}


	private void WallCollision ( Vector3 fromObject, ref Vector3 toTarget){

		Debug.Log ("target pos" + targetPosition);
		Debug.DrawLine (fromObject, toTarget, Color.blue);
		RaycastHit wallHit = new RaycastHit ();
		if (Physics.Linecast (fromObject, toTarget, out wallHit)) {
		
			Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
			toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
		}
	
	
	
	
	
	}




}
