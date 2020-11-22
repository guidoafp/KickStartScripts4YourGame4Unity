using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This Script make the object spin around! 
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// This Script was used in 3D mode and in a top view. 
/// The object you assigned this script must have a Rigidbody with a high mass number to and other collising objects as well.
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun!

public class SimpleSpin : MonoBehaviour
{
	public float speed = 1000f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime * 5);
	}
}
