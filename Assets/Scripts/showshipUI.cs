using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowshipUI : MonoBehaviour
{
    public GameObject uiObject1;
    public GameObject uiObject2;
    public GameObject uiObject3;
    public PlayerInventory playerInventory;
    public AudioSource audioSource;
    public AudioClip audioClipLessThan4;
    public AudioClip audioClipMoreThan4;
    public Diamond diamond;

    private bool playerInsideCollider = false;

    private void Start()
    {
        uiObject1.SetActive(false);
        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = true;
            uiObject1.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = false;
            uiObject1.SetActive(false);
            uiObject2.SetActive(false);
            uiObject3.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInsideCollider && Input.GetKeyDown(KeyCode.E))
        {
            
            StartCoroutine(WaitForSec());
            
            if (playerInventory.NumberOfDiamonds < 4)
            {
                uiObject2.SetActive(true);
                PlayAudioClip(audioClipLessThan4);
            }
            else if (playerInventory.NumberOfDiamonds >= 4)
            {
                uiObject3.SetActive(true);
                PlayAudioClip(audioClipMoreThan4);
            }
        }
    }

    private IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5f);
        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
    }

    private void PlayAudioClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}