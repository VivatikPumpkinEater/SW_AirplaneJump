using UnityEngine;
using System.Collections;

public class stone : MonoBehaviour {

	public Vector3 value;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		transform.RotateAround(transform.parent.transform.position, value, speed * Time.deltaTime);

	}
}
