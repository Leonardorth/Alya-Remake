using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowAbility : MonoBehaviour
{
    [SerializeField] Material glowMaterial;
    

    IEnumerator Start() {
        glowMaterial.EnableKeyword("_EMISSION");

        
        for (var intensity = 0; ;intensity += 100) {
            intensity += 100;
            glowMaterial.SetColor("_EmissiveColor", Color.white*intensity);
            yield return null;
        }
        
    }
    
    
}
