using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script that when clicking the object it changes its boolean state and color the Link’s Awakening, Color Dungeon puzzle inspired
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// This Script was used in 3D mode.
/// You will have to attach to the camera object this script.
/// Do not forget to make the Tags.
/// Do not forget to adress the MeshRenderer of each object.
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun
public class ClickMe : MonoBehaviour
{
    //Bool States of each object
    public bool FirstCube = false;
    public bool SecondCube = false;
    public bool ThirdCube = false;
    public bool FourthCube = false;

    //Game Objects 
    public GameObject N1;
    public GameObject N2;
    public GameObject N3;
    public GameObject N4;

    //MeshRenderer of each object 
    public MeshRenderer M1;
    public MeshRenderer M2;
    public MeshRenderer M3;
    public MeshRenderer M4;

    private void Start()
    {
        //Inicial color when game object is false
        M1.GetComponent<MeshRenderer>().material.color = Color.red;
        M2.GetComponent<MeshRenderer>().material.color = Color.red;
        M3.GetComponent<MeshRenderer>().material.color = Color.red;
        M4.GetComponent<MeshRenderer>().material.color = Color.red;

        //Each game object beggining state, feel free to play around to true and create your own puzzle. 
        FirstCube = false;
        SecondCube = false;
        ThirdCube = false;
        FourthCube = false;

    }

    void Update()
    {
        //Mouse input 
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast on camera theough mouse input 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, hitInfo: out RaycastHit hit))
            {
                // if the Raycast hit the game object Tag it Will Change its boolean state 
                if (hit.collider.gameObject.CompareTag("First"))
                {
                    FirstCube = !FirstCube;

                    // Feel free to play around with the states of each game object
                    //SecondCube = !SecondCube;
                    ThirdCube = !ThirdCube;
                    //FourthCube = !FourthCube;
                }

                if (hit.collider.gameObject.CompareTag("Second"))
                {
                    SecondCube = !SecondCube;

                    //FirstCube = !FirstCube;
                    //ThirdCube = !ThirdCube;
                    FourthCube = !FourthCube;
                }

                if (hit.collider.gameObject.CompareTag("Third"))
                {
                    ThirdCube = !ThirdCube;

                    //FirstCube = !FirstCube;
                    SecondCube = !SecondCube;
                    //FourthCube = !FourthCube;
                }

                if (hit.collider.gameObject.CompareTag("Fourth"))
                {
                    FourthCube = !FourthCube;

                    FirstCube = !FirstCube;
                    //SecondCube = !SecondCube;
                    //ThirdCube = !ThirdCube;
                }
            }

            //Changes the color by boolean state of  the object 

            if (FirstCube == true)
            {

                M1.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            
            if (FirstCube == false)
            {
                M1.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            if (SecondCube == true)
            {

                M2.GetComponent<MeshRenderer>().material.color = Color.blue;
            }

            if (SecondCube == false)
            {
                M2.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            if (ThirdCube == true)
            {

                M3.GetComponent<MeshRenderer>().material.color = Color.blue;
            }

            if (ThirdCube == false)
            {
                M3.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            if (FourthCube == true)
            {

                M4.GetComponent<MeshRenderer>().material.color = Color.blue;
            }

            if (FourthCube == false)
            {
                M4.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
