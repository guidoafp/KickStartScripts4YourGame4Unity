using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

/// This script allows object move back and forth (you can use the animate feature in unity to do that but you know)
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// Feel free to play around with the axis to have different movements. 
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun

public class SimpleAutoMove : MonoBehaviour
{
	//Speed value, feel free to change the value and see what happens :)
	public float speed = 1f;
	
	void Update()
	{

		// Front movement (Axis) Pick one! 

		//Move x axis
		UnityEngine.Vector3 vectorF = new UnityEngine.Vector3(Mathf.PingPong(Time.time * speed, 10f),transform.position.y, transform.position.z);
		
		//Move y axis
		//UnityEngine.Vector3 vectorF = new UnityEngine.Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 10f), transform.position.z);
		
		//Move z axis
		//UnityEngine.Vector3 vectorF = new UnityEngine.Vector3(transform.position.x,transform.position.y, Mathf.PingPong(Time.time * speed, 10f));

		//Vector reference 
		UnityEngine.Vector3 FrontStart = vectorF;
		
		//Vector transform is position, allows to change the position 
		transform.position = FrontStart;

		//Back axis (axis) Pick one!

		//Move x axis 
		UnityEngine.Vector3 vectorB = new UnityEngine.Vector3(Mathf.PingPong(Time.time * speed, 10),transform.position.y, transform.position.z);

		//Move y axis
		//UnityEngine.Vector3 vectorB = new UnityEngine.Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 10), transform.position.z);

		//Move z axis
		//UnityEngine.Vector3 vectorB = new UnityEngine.Vector3(transform.position.x,transform.position.y, Mathf.PingPong(Time.time * speed, 10));

		//Vector reference 
		UnityEngine.Vector3 BackFinish = vectorB;

		//Vector transform is position, allows to change the position 
		transform.position = BackFinish;
	}
}
