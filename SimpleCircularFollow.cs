using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script that when ploayer touches the object it follows the object in a circular movement
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// This Script was used in 3D mode and in a top view.
/// The game object that will follow needs "is a trigger" activated 
/// the Player ot the control object needs a tag called "Player"
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun

public class SimpleCircularFollow : MonoBehaviour
{
	public Transform Character;
	private bool challenged = false; // Check if touched

	//-------------------------------------------------------------------------------------------------------
	private int range;
	private float speed;
	private bool isThereAnyThing = false;
	public GameObject target;
	private float rotationSpeed;
	//--------------------------------------------------------------------------------------------------------

	void start()
	{
		range = 20;
		speed = 5f;
		rotationSpeed = 2f;
	}

	void Update()
	{

		if (challenged)
		{

			transform.Translate(Vector3.forward * 4 * Time.deltaTime * 4);

			//Look At Somthly Towards the Target.
			if (!isThereAnyThing)
			{
				Vector3 relativePos = Character.transform.position - transform.position/2;
				Quaternion rotation = Quaternion.LookRotation(relativePos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
			}
			// Enemy translate in forward direction.
			transform.Translate(Vector3.forward * Time.deltaTime * speed);

			//Checking for any Obstacle in front.
			// Two rays left and right to the object to detect the obstacle.
			Transform leftRay = transform;
			Transform rightRay = transform;

			//Use Phyics.RayCast to detect the obstacle 

			if (Physics.Raycast(leftRay.position + (transform.right * 2), transform.forward, range))
			{
				isThereAnyThing = true;
				transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * 2);
			}

			if (Physics.Raycast(rightRay.position - (transform.right * 2), transform.forward, range))
			{
				isThereAnyThing = true;
				transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * 2);
			}

			// Now Two More RayCast At The End of Object to detect that object has already overcome the obsatacle.

			if (Physics.Raycast(transform.position - (transform.forward * 2), transform.right, 2))
			{
				// Just making this boolean variable false it means there is nothing in front of object.
				isThereAnyThing = false;
			}

			if (Physics.Raycast(transform.position - (transform.forward * 2), -transform.right, 2))
			{
				// Just making this boolean variable false it means there is nothing in front of object.
				isThereAnyThing = false;
			}

			// Use to debug the Physics.RayCast. you can sse this on Scene, not in game mode 
			Debug.DrawRay(transform.position + (transform.right * 2), transform.forward * 10, Color.red);

			Debug.DrawRay(transform.position - (transform.right * 2), transform.forward * 10, Color.red);

			Debug.DrawRay(transform.position - (transform.forward * 1), -transform.right * 10, Color.yellow);

			Debug.DrawRay(transform.position - (transform.forward * 1), transform.right * 10, Color.yellow);
		}
	}

	// trigged on player hit
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			challenged = true;
		}
	}

}
