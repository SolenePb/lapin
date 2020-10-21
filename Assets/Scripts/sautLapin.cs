using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sautLapin : MonoBehaviour
{
    public static Transform target;
    public float vitesseSaut = 1.0f;

    //truc du prof pour empecher que le lapin mongolise
    private Vector3 targetPos;

    public float distStop = 1;
    public float distSlowDown = 2;
    private float vitesse = 0;
    public float vitesseMax = 1.0f;
    private float vitesseMin = 0.1f;
    public float acceleration = 1.0f;

    private bool atDestination = false;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    
    void Update()
    {
        if (target!= null) {
            targetPos = new Vector3(target.position.x, 1, target.position.z);

            //Distance au point
            Vector3 deplacement = targetPos - transform.position;
            float distance = deplacement.magnitude;
            float distanceRestante = distance - distStop;
            atDestination = distanceRestante <= 0;

            if (!atDestination)
            {
                //On cherche à aller le plus vite vers la destination, mais à ralentir quand on arrive
                //On reste entre vitesse min et max
                float vitesseVoulue = vitesseMax;
                if (distanceRestante < distSlowDown - distStop)
                    vitesseVoulue = Mathf.Lerp(vitesseMax, vitesseMin, 1.0f - (distanceRestante / (distSlowDown - distStop)));

                //Prise en compte de l'accélération
                if (vitesseVoulue > vitesse)
                    vitesse = Mathf.Min(vitesse + acceleration * Time.deltaTime, vitesseVoulue);
                else
                    vitesse = vitesseVoulue; //On freine parfaitement bien

                //Déplacement
                deplacement = deplacement.normalized * vitesse * Time.deltaTime;
                transform.position += deplacement;

            }
        }
        

    }

    /*
    Vector3 deplacement = new Vector3(target.position.x, 1, target.position.z) - new Vector3(this.transform.position.x, 1, this.transform.position.z);
    deplacement = deplacement.normalized* vitesseSaut * Time.deltaTime;
            transform.position += deplacement; */
}
