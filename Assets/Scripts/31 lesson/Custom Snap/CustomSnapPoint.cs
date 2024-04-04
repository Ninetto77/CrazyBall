using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSnapPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
