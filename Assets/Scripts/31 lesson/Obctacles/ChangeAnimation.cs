using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    private Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void ChangeRandomAnimation()
    {
        int number = Random.Range(1,4);
        mAnimator.SetInteger("Number", number);
    }

}
