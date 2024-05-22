using UnityEngine;
using System.Collections;

public class ballleft : MonoBehaviour {

	public float distance;

	// Use this for initialization
	void Start () {
		iTween.MoveBy (gameObject, iTween.Hash("x", distance,"easetype", iTween.EaseType.easeInQuad, "time", 0.15f,"delay",3,"looptype", iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
