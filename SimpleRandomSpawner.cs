using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script that spawns gameobject preferebirable a prefab gameobject
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// This Script was used in 3D mode and in a top view. 
/// This script was assigned on an empty gameobject.
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun!

/// </summary>
public class SimpleRandomSpawner : MonoBehaviour
{
	//Prefab game object that you will spwawn
	public GameObject GameObjectPrefab;

	void Start()
	{
	//Method for repeating the object, please feel free to play with the values!
		InvokeRepeating("SpawnObject", 1f, 4f);
	}

	void SpawnObject()
	{
		//Gets the Prefab game object and instatiate it 
		GameObject GamePrefab = Instantiate(GameObjectPrefab);
		
		//Gets random position to place game object, inside the space of a sphere 
		Vector3 randomPoint = Random.insideUnitSphere.normalized * 1f;

		// Places the Prefab to their new random position, based on X,Y,Z Axis   
		GamePrefab.transform.position = new Vector3(randomPoint.x, randomPoint.y, randomPoint.z);
	  //GamePrefab.transform.position = new Vector3(0, 0, 0);

	}
}
