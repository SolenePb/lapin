using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfAnimationStateController : MonoBehaviour
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
        //gestion des animations du loup

        if (deplacementsLoup.etatDuSautLoup > 0f && deplacementsLoup.etatDuSautLoup < 0.15f)
        {
            animator.SetBool("WolfJumpEngaged", true);
        }

        if (deplacementsLoup.etatDuSautLoup >= 0.15f && deplacementsLoup.etatDuSautLoup < 0.7f)
        {
            animator.SetBool("WolfJumpEngaged", false);
            animator.SetBool("WolfJumpHappening", true);

        }

        if (deplacementsLoup.etatDuSautLoup >= 0.7f && deplacementsLoup.etatDuSautLoup <= 1f)
        {
            animator.SetBool("WolfJumpHappening", false);
            animator.SetBool("WolfJumpEnding", true);
        }

        if (deplacementsLoup.etatDuSautLoup == 0f)
        {
            animator.SetBool("WolfJumpEnding", false);
            animator.SetBool("WolfJumpFinished", true);
        }

    }
}
