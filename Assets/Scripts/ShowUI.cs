using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject; 
    void Start()
    {
       uiObject.SetActive(false); 
    }
    void OnTriggerEnter (Collider PlayerCapsule)
    {
        if (PlayerCapsule.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(18);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
