using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    private Animator animator;
    private bool canOpenDoors = false;

    private void Update()
    {
        if (canOpenDoors)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator = Door.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetBool("IsOpened", true);
                }
            }
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("Player"))
    //    {
    //        GameManager.instance.ShowEnterKey(true);
    //        canOpenDoors = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("Player"))
    //    {
    //        GameManager.instance.ShowEnterKey(false);
    //        canOpenDoors = false;
    //    }
    //}
}
