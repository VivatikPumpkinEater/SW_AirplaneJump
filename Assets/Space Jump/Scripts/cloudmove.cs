using UnityEngine;
using System.Collections;

public class cloudmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		iTween.MoveBy(this.gameObject, iTween.Hash("z", -100, "easetype", iTween.EaseType.easeOutCirc, "time", 80)); 
		Destroy (this.gameObject, 30);
	}

	void Update () {

	}

}
