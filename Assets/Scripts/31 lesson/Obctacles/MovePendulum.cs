using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePendulum : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxAngle;

    private float angle;

    void Update()
    {
        angle = maxAngle * Mathf.Sin(Time.time * moveSpeed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

   
}
