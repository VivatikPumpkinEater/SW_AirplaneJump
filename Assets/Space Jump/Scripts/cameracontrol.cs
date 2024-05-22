using UnityEngine;
using System.Collections;

public class cameracontrol : MonoBehaviour {	

	private GameObject Player;
	public float lerpTime ;



	void Start(){
	
		Application.targetFrameRate = 60;
		Player = GameObject.FindGameObjectWithTag("Player");

	}

	// Update is called once per frame
	void Update () {

	//	Player = GameObject.Find ("playerbody(Clone)");

	}

	void LateUpdate () {

		lerpTowardsBallTransform();	
	}

	void lerpTowardsBallTransform()
	{
		
		if (Player.gameObject!= null) {
			Vector3  newPosition = Player.transform.position;
			
			newPosition.z=Player.transform.position.z-7.5f;
			newPosition.y=Player.transform.position.y+1.1f;
			newPosition.x=Player.transform.position.x-0.1f;
			/*
			if(newPosition.y<=-10)newPosition.y=-10;
			if(newPosition.y>=21.5f)newPosition.y=21.5f;
			*/
			//lerp between the current position and the new position
			transform.position = Vector3.Lerp(transform.position,newPosition,Time.smoothDeltaTime * lerpTime);
		}
	
	}
	
}
