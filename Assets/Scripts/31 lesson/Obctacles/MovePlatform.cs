using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private GameObject targetPosition;
    [SerializeField] private float timeToMove = 4f;

    private float elapsedTime;
    private float delta;
    private Vector3 startPosition;
    private bool canMove = true;
    private bool moveForward = true;

    void Start()
    {   
        startPosition = transform.position;
        elapsedTime = 0;
    }

    void Update()
    {
       if (canMove)
        {
            if (elapsedTime < timeToMove)
            {
                delta = elapsedTime / timeToMove;
                if (moveForward)
                {
                    transform.position = Vector3.Lerp(startPosition, targetPosition.transform.position, delta);
                }
                else if (!moveForward)
                {
                    transform.position = Vector3.Lerp(targetPosition.transform.position, startPosition, delta);
                }
                elapsedTime += Time.deltaTime;

                if (elapsedTime > timeToMove)
                {
                    moveForward = !moveForward;
                    elapsedTime = 0;
                }
            }
        }

    }

}
