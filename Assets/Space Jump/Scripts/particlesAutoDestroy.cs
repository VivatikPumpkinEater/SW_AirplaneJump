using UnityEngine;
using System.Collections;

public class particlesAutoDestroy : MonoBehaviour {




	// Use this for initialization
	void Start () {
	

	
		}


	void OnEnable() 
	{
		Invoke ("repooling", 5);
	}

	private void repooling()
	{
		DestroyObject (gameObject);
	}
	


	
}
