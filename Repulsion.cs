using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This Script make the Sphere object go away when collide with another!
/// Version of Unity used on this script 2019.3.7f1 LTS(Long Term Support)
/// This Script was used in 3D mode and in a top view. 
/// The object you assigned this script (the one that will be collide) does not need a Rigidbody.
/// The intent of this script is to help beginners and those that have limited code skills to make games!
/// Have Fun!
public class Repulsion : MonoBehaviour
{
    // Public variable
    public GameObject SphereCentral; // The attached central sphere
    public float sphereCentralDistance = 1;
    public float sphereSpeed = 3F;
    public float fixedY = 1;
    public float currentDistance; // PUBLIC TO DEBUG

    // Private variables
    private bool isTargetReached = false;
    private bool isInRepulsionZone = false; // True when we are in the repulsion zone
    private Vector3 targetedPosition; // Target position from the repulsion effect

    // Update is called once per frame
    void Update()
    {
        if (this.SphereCentral == null) { return; }


        this.currentDistance = Vector3.Distance(this.transform.position, this.SphereCentral.transform.position);

        if (!this.isTargetReached)
        {
            this.targetedPosition.y = this.fixedY; // force fixed y coordinate

            this.transform.position = Vector3.Lerp(this.transform.position, this.targetedPosition, Time.deltaTime * this.sphereSpeed *2);
           
            if (this.currentDistance > this.sphereCentralDistance - 1F)
            {
                this.transform.position = targetedPosition;
                this.isTargetReached = true;
            }
        }

        if (this.currentDistance != this.sphereCentralDistance - 1F)
        {
            this.isTargetReached = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ALL: CHECK TAG FOR CENTRAL SPHERE
        Debug.LogWarning("SphereOrbit enters trigger of central ! " + other.name);
        this.SphereCentral = other.gameObject; // Linking the central sphere gameObject
        this.isInRepulsionZone = true;
        this.isTargetReached = false;

        // Compute new position
        Vector3 position = this.transform.position;
        Vector3 positionSphereCentral = this.SphereCentral.transform.position;
        Vector3 direction = positionSphereCentral - position;
        Vector3 normalized = Vector3.Normalize(direction) * -1; // -1 because we want to repulse to the opposite side

        print(sphereCentralDistance);
        this.targetedPosition = normalized * sphereCentralDistance;
        this.targetedPosition += normalized * 3F; // Adding 0.01F because we want the sphere to go out of the zone
    }

    void OnTriggerExit(Collider other)
    {
  
        this.isInRepulsionZone = false;
    }

}
