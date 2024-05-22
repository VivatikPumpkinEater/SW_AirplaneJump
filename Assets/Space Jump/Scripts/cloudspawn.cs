using UnityEngine;
using System.Collections;



public class cloudspawn : MonoBehaviour {

	public GameObject[] cloud;
	float timepadding;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timepadding += Time.deltaTime;
		if (timepadding >= 1) {
			cloudcreat();
			timepadding = 0;
		}


	}

	void cloudcreat(){
		Vector3 cloudpos = new Vector3 (Random.Range (-6, 2), Random.Range (-2, -0.5f), this.transform.position.z);
		Instantiate (cloud [UnityEngine.Random.Range(0,cloud.Length-1)],cloudpos,Quaternion.identity);

	}

}
