using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCullisOpen : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject sandParticles;
    [SerializeField] int speed;
    [SerializeField] float moveAmount;
    bool nearDoor;
    bool istriggered;
    private float startTime;
    private Vector3 start;
    private Vector3 des;
    private float journeyLength;

    public AudioClip triggerSound;
    AudioSource audioSource;

    void Start()
    {
        start = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
        des = new Vector3(door.transform.position.x, moveAmount, door.transform.position.z);
        journeyLength = Vector3.Distance(start, des);
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        if (nearDoor == true)
        {
            door.transform.position = Vector3.Lerp(start, des, fractionOfJourney);
        }

    }
    void OnTriggerEnter(Collider other)
    {

        if (istriggered == false && other.tag == "PushableStoneCube")
        {
            startTime = Time.time;
            nearDoor = true;
            audioSource.PlayOneShot(triggerSound, 0.5f);
            sandParticles.SetActive(true);
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
