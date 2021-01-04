using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimEnabler : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SwimEnabler")
        {
            animator.SetBool("isSwimming", true);
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "SwimEnabler")
        {
            animator.SetBool("isSwimming", false);
        }
    }
}
