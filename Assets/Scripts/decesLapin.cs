﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decesLapin : MonoBehaviour
{
    private static bool collisionLapinLoup = false;
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.name == "loup" || collisionInfo.collider.name == "loup (1)")
        {
            collisionLapinLoup = true;
            FindObjectOfType<GameManager>().GameOVER();
        }
    }

  
}
