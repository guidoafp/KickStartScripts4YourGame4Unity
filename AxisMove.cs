using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script that allows a Rigidbody to move specific X,Y on arrow Keys Y with W/S Key.
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// This Script was used in 3D mode and in a top view. 
/// The object you assigned this script must have a Rigidbody to work.
/// Constraint X, Y and Z Freeze Rotation on game object Rigidbody for linear movement.
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun

public class AxisMove : MonoBehaviour
{
    // the Object Rigidbody you assigned 
    Rigidbody move_Rigidbody;
   
    // The Axis (X,Y,Z) in Vector 3 
    Vector3 XAxis;
    Vector3 YAxis;
    Vector3 ZAxis;

    void Start()
    {
        move_Rigidbody = GetComponent<Rigidbody>();

        // Moving the Rigidbody in the the respect axis by setting up the each vector
        // Feel free to change the values, for the fun of it!
        XAxis = new Vector3(50, 0, 0);
        YAxis = new Vector3(0, 50, 0);
        ZAxis = new Vector3(0, 0, 50);

    }

    void Update()
    {
        // Press Up arrow and game object goes Forward (Z Axis)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move_Rigidbody.velocity = ZAxis;
        }

        // Press Down arrow and game object goes Backward (Z Axis)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move_Rigidbody.velocity = -ZAxis;
        }

        // Press Left arrow and game object goes Left (X Axis)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move_Rigidbody.velocity = -XAxis;
        }

        // Press Right arrow and object goes Right (X Axis)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move_Rigidbody.velocity = XAxis;
        }

        // Press W key and object goes Up (Y Axis)
        if (Input.GetKeyDown(KeyCode.W))
        {
            move_Rigidbody.velocity = YAxis;
        }

        // Press S key and object goes Down (Y Axis)
        if (Input.GetKeyDown(KeyCode.S))
        {
            move_Rigidbody.velocity = -YAxis;
        }
    }


}
