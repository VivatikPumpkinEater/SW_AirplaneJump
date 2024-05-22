using UnityEngine;
using System.Collections;

public class AutoMoveAndRotate : MonoBehaviour {

	public Vector3andSpace moveUnitsPerSecond;
	public Vector3andSpace rotateDegreesPerSecond;
	public bool ignoreTimescale;
	float lastRealTime;

	public float timePadding=0;
	public float timerule=4;

	public bool starting=false;

	void Start()
	{
		lastRealTime = Time.realtimeSinceStartup;

	}

	// Update is called once per frame
	void Update () {

		if (starting) {

						float deltaTime = Time.deltaTime;
						if (ignoreTimescale) {
								deltaTime = (Time.realtimeSinceStartup - lastRealTime);
								lastRealTime = Time.realtimeSinceStartup;
						}
						transform.Translate (moveUnitsPerSecond.value * deltaTime, moveUnitsPerSecond.space);
						transform.Rotate (rotateDegreesPerSecond.value * deltaTime, moveUnitsPerSecond.space);

						timePadding += Time.deltaTime;
						if (timePadding >= timerule) {
				rotateDegreesPerSecond.value.x = rotateDegreesPerSecond.value.x * -1;
				rotateDegreesPerSecond.value.y = rotateDegreesPerSecond.value.y * -1;
								rotateDegreesPerSecond.value.z = rotateDegreesPerSecond.value.z * -1;
				moveUnitsPerSecond.value.x=moveUnitsPerSecond.value.x*-1;
				moveUnitsPerSecond.value.y=moveUnitsPerSecond.value.y*-1;
				moveUnitsPerSecond.value.z=moveUnitsPerSecond.value.z*-1;
								timePadding = 0;
								
						}
				}
						
	}

	[System.Serializable]
	public class Vector3andSpace
	{
		public Vector3 value;
		public Space space = Space.Self;
	}

}
