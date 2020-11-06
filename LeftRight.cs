using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// This Script checks the sequence of hits between right and left, and avoids repeating, triggering the same object. 
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// Don’t forget to activate is a trigger in game object, not with the script.
/// Don’t forget to make a UI object and add text objects to see the numbers and feedback
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun!

public class LeftRight : MonoBehaviour
{
    //Counting the hits between right and left
    public static int count;

    // counting the number of right and left sequences done
    public static int cicle;

    //Text that appears on game, please do not forget to put a canvas and text game objects inside the canvas!
    //Count Text
    public Text CountText;
    
    //Cicle text to show number of cicles
    public Text CicleText;
    
    //Hits the right object
    public Text RightText;

    //Hits the left object
    public Text LeftText;

    //Text that shows if the sequence is being followed
    public Text WhichSideText;

    //Check hit bool
    public bool GotHit = false;

    //game object bool to check if trigger statment in right 
    public bool RightHand = false;

    //game object bool to check if trigger statement in left
    public bool LeftHand = false;

    //Given started values for count, cicle and empty text for “WichSide”
    public void Start()
    {
        count = 0;
        cicle = 0;
        WhichSideText.text = "";
    }
    
    //Check if count to confirm right and left sequence and count the cicles 
    public void Update()
    {
        if (count == 2)
        {
            WhichSideText.text = "Hit!";
            count = 0;
            cicle = cicle + 1;
            Debug.Log("counting" + count);
            Debug.Log("Cicles" + cicle);

            setText();
        }

        if (count <= 0)
        {
            count = 0;
            setText();
        }
    }

    //check trigger right or left 
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Right") && RightHand == false && (GotHit == false))
        {
            GotHit = true;
            Debug.Log("Right Hand");
            RightText.text = "Right!";
            WhichSideText.text = "";

            if (GotHit == true)
            {
                RightHand = true;
                LeftHand = false;
                count = count + 1;
                Debug.Log("one Right" + count);
                setText();
            }

        }

        if (other.gameObject.CompareTag("Right") && RightHand == true && (GotHit == false))
        {
            Debug.Log("Right Hand Again? Start again!");
            WhichSideText.text = "Right Hand Again? Start again!";
            count = count - 1;
            Debug.Log("Minus one Right" + count);
            GotHit = false;
            setText();

            if (RightHand == true)
            {
                RightHand = false;
                LeftHand = false; 
            }
        }

        if (other.gameObject.CompareTag("Left") && LeftHand == false && (GotHit == false))
        {
            
            GotHit = true;
            Debug.Log("Left Hand");
            LeftText.text = "Left!";
            WhichSideText.text = "";

            if (GotHit == true)
            {
                RightHand = false;
                LeftHand = true;
                count = count + 1;
                Debug.Log("one L" + count);
                setText();
            }
        }

        if (other.gameObject.CompareTag("Left") && LeftHand == true && (GotHit == false))
        {
            Debug.Log("Left Hand Again? Start again!");
            WhichSideText.text = "Left Hand Again? Start again!";
            count = count - 1;
            Debug.Log("Minus one Left" + count);
            GotHit = false;
            setText();

            if (LeftHand == true)
            {
                RightHand = false;
                LeftHand = false;
            }
        }
    }

    //avoids multiple checks and counts 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Right") && RightHand == true && (GotHit == true))
        {
            GotHit = false;
            RightText.text = "";
        }

        if (other.gameObject.CompareTag("Left") && LeftHand == true && (GotHit == true))
        {
            GotHit = false;
            LeftText.text = "";
        }
    }

    // Add information to the text
    void setText()
    {
        CountText.text = "Count: " + count.ToString();
        CicleText.text = "Cicle: " + cicle.ToString(); 
    } 
}
