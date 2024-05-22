using UnityEngine;
using System.Collections;

public class ballflip : MonoBehaviour {


	private bool stoproatted=false;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("srotate", 1, 4);
	}


	private void srotate()
	{
		if(!stoproatted)
		iTween.RotateBy(gameObject, iTween.Hash("y", 0.5f,"easetype", iTween.EaseType.easeInQuad, "time", 0.25f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void stoprotate()
	{
		stoproatted = true;
		//iTween.Pause ();

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player"&&!stoproatted) {
			stoprotate();
			}
	}
}
