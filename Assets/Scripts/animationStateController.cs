using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sautLapin.etatDuSaut > 0f && sautLapin.etatDuSaut < 0.2f) 
        {
            animator.SetBool("JumpEngaged",true);
        }

        if (sautLapin.etatDuSaut >= 0.2f && sautLapin.etatDuSaut < 0.7f)
        {
            animator.SetBool("JumpEngaged", false);
            animator.SetBool("JumpHappening", true);
        }

        if (sautLapin.etatDuSaut >= 0.7f && sautLapin.etatDuSaut <= 1f)
        {
            animator.SetBool("JumpHappening", false);
            animator.SetBool("JumpEnding", true);
        }

        if (sautLapin.etatDuSaut == 0f)
        {
            animator.SetBool("JumpEnding", false);
            animator.SetBool("JumpFinished", true);
        }
    }
}
