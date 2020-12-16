using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decesLapin : MonoBehaviour
{
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "loup")
        {
            Debug.Log("perdu hihi");
        }
    }
}
