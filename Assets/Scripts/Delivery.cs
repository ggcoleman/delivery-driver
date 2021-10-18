using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool packageCollected; 

    [SerializeField]
    float destroyDelay = 0.3f;

    [SerializeField]
    Color32 hasPackageColour = new Color32(1, 1, 1, 1);

    [SerializeField]
    Color32 noPackageColour = new Color32(1, 255, 1, 1);

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
            spriteRenderer.color = hasPackageColour;

            Destroy(other.gameObject, destroyDelay);          
        }

        if(other.tag == "Customer" && packageCollected)
        {
            Debug.Log("Package Delivered"); 
            packageCollected = false;
            spriteRenderer.color = noPackageColour;
        }

    }
}
