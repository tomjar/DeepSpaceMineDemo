using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	
	void OnTriggerEnter(Collider other) 
	{
		//you hit the asteroid!
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		//asteroid hit player
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver ();
			//Application.Quit();
			//Reese 4/16/2014, simply reload the game if they are hit TODO: do something else other than reload the game :-D
			Application.LoadLevel(0);
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}