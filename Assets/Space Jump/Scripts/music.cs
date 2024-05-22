using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

	// Dont destroy on load and prevent duplicate
	private static bool created = false;
	void Awake()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
