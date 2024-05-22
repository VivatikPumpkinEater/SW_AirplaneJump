using UnityEngine;
using System.Collections;

public class objectAutoDestroy : MonoBehaviour {

	public float timer;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, timer);

	}


}
