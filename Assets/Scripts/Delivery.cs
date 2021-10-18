using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool packageCollected; 

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!!");
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !packageCollected)
        {
            Debug.Log("Package Collected");
            packageCollected = true;    
        }

        if(other.tag == "Customer" && packageCollected)
        {
            Debug.Log("Package Delivered"); 
            packageCollected = false;
        }

    }
}
