using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ScaleBy(gameObject, iTween.Hash(
			"z", 0.9f, 
			"time", 0.3f,
			"easetype", "easeInOutQuad",
			"looptype", iTween.LoopType.pingPong
			));
	}
	
	// Update is called once per frame
	void Update () {
	
	

	}


}
