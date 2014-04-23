using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("Hello I was called!");
	}
	
	// Update is called once per frame
	void Update () {
		//Reese 4-16-2014 this will simply exit the game after the escape key is pressed.
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

	}
}
