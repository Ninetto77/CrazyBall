using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObject : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private bool IsActive;
    private bool canChangeState = false;

    private void Start()
    {
        if (target != null)
        {
            if (target.activeSelf ==true)
            {
                IsActive = true;
            }
        }
    }

    private void Update()
    {
        if (canChangeState)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                target.SetActive(!IsActive);
                IsActive = !IsActive;
            }

        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("Player"))
    //    {
    //        GameManager.instance.ShowEnterKey(true);
    //        canChangeState = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("Player"))
    //    {
    //        GameManager.instance.ShowEnterKey(false);
    //        canChangeState = false;
    //    }
    //}
}
