using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPushing : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] Vector3 offset;
    [SerializeField] float raycastFrequency;
    [SerializeField] float maxRayDist = 1f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("CheckForPushableObject");
    }
    

    IEnumerator CheckForPushableObject()
    {
        while (true)
        {
            
            if (Physics.Raycast(transform.position + offset, transform.forward, out hit, maxRayDist))
            {
                Debug.DrawRay(transform.position + offset, transform.forward, Color.red, maxRayDist);
                if (hit.collider.CompareTag("PushableStoneCube"))
                {
                    animator.SetBool("isPushing", true);
                }
                
            }
            else 
                if (animator.GetBool("isPushing"))
                {
                    animator.SetBool("isPushing", false);
                }

            yield return new WaitForSeconds(raycastFrequency);

        }
    }
    
}
