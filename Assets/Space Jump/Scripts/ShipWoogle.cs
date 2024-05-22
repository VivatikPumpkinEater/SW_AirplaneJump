using UnityEngine;
using System.Collections;

public class ShipWoogle : MonoBehaviour {

	public float frequency;
	public float amplitude;

	Vector3 initialPos;
	private bool stopmove=false;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;

		frequency = frequency + Random.Range (-0.2f, 0.2f);
		amplitude = amplitude + Random.Range (-0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopmove) {
			transform.position = initialPos + (Mathf.Sin (Time.time * frequency) * Vector3.left) * amplitude;
		}

	}

	public void stopmoving()
	{
		if (!stopmove) {
			stopmove = true;
			//transform.position=initialPos;
			Invoke ("startmoving", 0.1f);
		}
	}

	private void startmoving()
	{

		iTween.MoveTo(gameObject,initialPos,0.5f);
		//Invoke ("startmovedelay", 1f);

	}

	void startmovedelay(){

		stopmove = false;
	}

}
