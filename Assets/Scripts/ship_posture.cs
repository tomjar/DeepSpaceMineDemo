using UnityEngine;
using System.Collections;

public class ship_posture : MonoBehaviour {

	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("left") || Input.GetKey ("a")){
			transform.rotation = Quaternion.Euler(0,0,90);
		}
		else if(Input.GetKey ("right")|| Input.GetKey ("d")){
			transform.rotation = Quaternion.Euler(0,0,-90);
		}
	}
}
