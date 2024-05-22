using UnityEngine;
using System.Collections;

public class myball : MonoBehaviour {
	
	public bool ifgrounded = false ;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			ifgrounded=true;
			iTween.MoveBy (gameObject, iTween.Hash ("y", -0.2f, "easetype", iTween.EaseType.easeInCubic, "time", 0.1f));
			iTween.MoveBy (gameObject, iTween.Hash ("y", 0.2f, "easetype", iTween.EaseType.easeInQuad, "time", 0.25f,"delay",0.1f));
		}
	}

}
