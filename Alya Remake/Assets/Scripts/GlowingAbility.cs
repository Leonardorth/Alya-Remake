using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingAbility : MonoBehaviour
{
    [SerializeField] Material glowMaterial;
    [SerializeField] GameObject light;
    

    private void Start()
    {
        glowMaterial.EnableKeyword("_EMISSION");
        light.GetComponentInChildren<Light>();
    }

    [SerializeField] float maxIntensity = 100;

    float actualIntensity = 0;

    IEnumerator StartEmission()
    {
        for (var intensity = actualIntensity; intensity < maxIntensity; intensity += 100)
        {
            actualIntensity += 100;
            intensity += 100;

            glowMaterial.SetColor("_EmissiveColor", Color.white * intensity);
            yield return null;
        }

    }

    
    IEnumerator KillEmission()
    {
        for (var intensity = actualIntensity ; intensity >= 100 ; intensity -= 100)
        {
            actualIntensity -= 100;
            intensity -= 100;
            glowMaterial.SetColor("_EmissiveColor", Color.white * intensity);
            yield return null;
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(StartEmission());
            light.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            StartCoroutine(KillEmission());
            light.SetActive(false);
        }


    }
}
