using UnityEngine;
using System.Collections;

public class stoneboom : MonoBehaviour {

	private bool stoproatted=false;
	public float scale;
	
	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("sboom", 1, 7);
	}
	
	
	private void sboom()
	{
		if (!stoproatted) {
			gameObject.GetComponent<Collider>().enabled=true;
			iTween.ScaleTo (gameObject, iTween.Hash ("x", scale, "y", scale, "z", scale, "easetype", iTween.EaseType.easeOutBounce, "time", 0.5f));
			iTween.ScaleTo (gameObject, iTween.Hash ("x", 0.5f, "y", 0.5f, "z", 0.5f, "easetype", iTween.EaseType.easeInCubic, "time", 0.5f,"delay",3));
	
			Invoke("closecollider",3);
		}
	}

	private void closecollider()
	{
		gameObject.GetComponent<Collider>().enabled=false;

	}
	
	public void stoprotate()
	{
		stoproatted = true;
		//iTween.Pause ();
		
	}
	

}
