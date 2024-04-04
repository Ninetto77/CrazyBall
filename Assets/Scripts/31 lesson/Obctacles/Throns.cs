using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Mode
{
    auto,
    manual
}



public class Throns : MonoBehaviour
{
    public Mode mode;
    private bool IsUp = true;
    private bool canMove = true;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (mode == Mode.auto)
        {
            animator.SetTrigger("Start");
            StartCoroutine(MoveThrons());
            IsUp = true;
        }
    }

    private void ChangeIsUp()
    {
        if (IsUp)
        {
            animator.SetBool("IsUp", true);
        }
        else
        {
            if (!IsUp)
            {
                animator.SetBool("IsUp", false);
            }
        }

        IsUp = !IsUp;
    }

    private IEnumerator MoveThrons()
    {
        while (true)
        {
            ChangeIsUp();
            yield return new WaitForSeconds(3);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (mode == Mode.manual & canMove == true)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                Destroy(this.gameObject.GetComponent<BoxCollider>());
                animator.SetTrigger("Appear");
                animator.SetBool("IsUp", true);
                canMove = false;
            }
 
        }
    }
}
