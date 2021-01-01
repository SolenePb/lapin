using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementsLoup : MonoBehaviour
{
    public List<Transform> chemin;
    private Vector3 departLoup;
    private Vector3 arriveeLoup;
    private int posActuelleLoup;
    private int longueurChemin;
    public static float etatDuSautLoup = 0f;

    // Start is called before the first frame update
    void Start()
    {

        longueurChemin = chemin.Count;
        posActuelleLoup = 0;
        departLoup = new Vector3(chemin[posActuelleLoup].position.x, 1, chemin[posActuelleLoup].position.z);
        arriveeLoup = new Vector3(chemin[posActuelleLoup].position.x, 1, chemin[posActuelleLoup].position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (sautLapin.target != null && sautLapin.target.position != sautLapin.derniereTuile)
        {
            

            if (sautLapin.aSaute == true)
            {
                posActuelleLoup += 1;
            }

            if (sautLapin.aSaute == true && posActuelleLoup == longueurChemin)
            {
                posActuelleLoup = 0;
            }

            sautLapin.aSaute = false;

            if (etatDuSautLoup == 0f)
            {
                arriveeLoup = new Vector3(chemin[posActuelleLoup].position.x, 1, chemin[posActuelleLoup].position.z);
            }

            if (departLoup == arriveeLoup)
            {
                return;
            }

            etatDuSautLoup += sautLapin.vitesse * Time.deltaTime;


            if (etatDuSautLoup >= 1.0f)
            {
                transform.position = arriveeLoup;
                departLoup = arriveeLoup;
                etatDuSautLoup = 0;
            }

            else
            {
                transform.position = Vector3.Lerp(departLoup, arriveeLoup, etatDuSautLoup) + new Vector3(0, -2.0f * 4.0f * (etatDuSautLoup - 0.5f) * (etatDuSautLoup - 0.5f) + 2.0f, 0);

            }

            //rotation loup

            
            // Determine which direction to rotate towards
            Vector3 targetDirection = arriveeLoup - departLoup;

            // The step size is equal to speed times frame time.
            float singleStep = 10f * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);


            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);

        }
    }
}
