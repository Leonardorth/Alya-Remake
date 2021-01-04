using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPressurePlate : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool istriggered;
    

    public AudioClip triggerSound;
    AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

    }
    
    void OnTriggerEnter(Collider other)
    {

        if (istriggered == false && other.tag == "PushableStoneCube")
        {
            door.SetActive(true);
            audioSource.PlayOneShot(triggerSound, 0.5f);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PushableStoneCube")
        {
            istriggered = true;
        }

    }
}
