﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	
	// Stuff having to do with mouselook
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;
	// End stuff having to do with mouselook
	
	//Ship posture
	public float lr_Rotate_MaxAngle = -90.0f;
	public float lr_m_Angle = 0.0f;
	public float m_SmoothValue = 3.0f;
	
	void Awake()
	{
		lr_m_Angle = transform.rotation.eulerAngles.z;
		//ht_m_Angle = transform.rotation.eulerAngles.x;
		lr_Rotate_MaxAngle += lr_m_Angle;
		//ht_Rotate_MaxAngle += ht_m_Angle;
	}
	
	void Update ()
	{
		
		// Stuff having to do with mouselook
		if (axes == RotationAxes.MouseXAndY)
		{
			//ship posture adjust
			float lr_Input = Input.GetAxis("Horizontal");
			lr_m_Angle = Mathf.Lerp(lr_m_Angle, lr_Rotate_MaxAngle * lr_Input, Time.deltaTime * m_SmoothValue);
			Vector3 euler = transform.rotation.eulerAngles;
			//euler.z = lr_m_Angle;
			//transform.localRotation = Quaternion.Euler(euler);
			
			//float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivityX;
			//rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY += Input.GetAxis("Vertical") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, lr_m_Angle);
			
			
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
		// End stuff having to do with mouselook
	}
	
	void FixedUpdate ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			Instantiate(shot, shotSpawn.position, rigidbody.rotation);
			audio.Play ();
		}
		
		float moveHorizontal = Input.GetAxis ("Speed");
		//float moveVertical = Input.GetAxis ("Vertical");
		
		// Moves the ship according to its orientation when appropriate keys are pressed
		//transform.Translate (moveHorizontal/50 * speed, 0, moveVertical/50 * speed, Space.Self);
		transform.Translate (0, 0, moveHorizontal/50 * speed, Space.Self);
		
		// Positional clamping is removed; player should be able to move anywhere
		/*rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);*/
		
		//rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}