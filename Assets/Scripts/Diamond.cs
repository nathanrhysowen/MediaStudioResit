using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = Quaternion. Euler(90f, Time.time * 100f, 0);
    }
   

   private void OnTriggerEnter(Collider other)
   {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);
        }
   }
        
}
