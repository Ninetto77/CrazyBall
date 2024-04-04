using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float timeToMove = 4f;

    private float elapsedTime;
    private float delta;
    private Vector3 startPosition;
    private bool canMove = false;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (canMove)
        {
            MoveTheBridge();
        }
    }

    private void MoveTheBridge()
    {
        if (elapsedTime < timeToMove)
        {
            delta = elapsedTime / timeToMove;
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, delta);
            elapsedTime += Time.deltaTime;

        }
        else
        {
            transform.position = targetPosition.position;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Get Player");
            canMove = true;
        }
    }


   
}
