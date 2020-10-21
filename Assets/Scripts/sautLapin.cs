using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sautLapin : MonoBehaviour
{
    public static Transform target;
    public static Vector3 derniereTuile;
    private float etatDuSaut = 0f;
    public static Vector3 targetPos;
    public static float vitesse = 1.0f;
    public static float distanceSaut = 8.0f;
    public static bool aSaute = false;


    // Start is called before the first frame update
    void Start()
    {
        derniereTuile = transform.position;

    }

    // Update is called once per frame
    
    void Update()
    {

        if (target!= null) {
            if(etatDuSaut == 0f) {

                targetPos = new Vector3(target.position.x, 1, target.position.z);
            }

            if(targetPos == derniereTuile || (targetPos - derniereTuile).magnitude >= distanceSaut)
            {
                return;
            }

            if (etatDuSaut == 0f)
            {
                aSaute = true;
            }

            etatDuSaut += vitesse * Time.deltaTime;


            if (etatDuSaut >= 1.0f)
            {
                transform.position = targetPos;
                derniereTuile = targetPos;
                etatDuSaut = 0;
            }

            else
            {
                transform.position = Vector3.Lerp(derniereTuile, targetPos, etatDuSaut) + new Vector3(0, -2.0f * 4.0f * (etatDuSaut-0.5f)*(etatDuSaut - 0.5f) + 2.0f, 0);

            }

            }
        }
        

    }