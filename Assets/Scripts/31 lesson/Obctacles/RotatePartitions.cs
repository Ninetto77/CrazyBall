using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePartitions : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private Vector3 rotateVector;
    private Vector3 curRotateVector;


    void Update()
    {
        curRotateVector += new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(curRotateVector);
    }
}
