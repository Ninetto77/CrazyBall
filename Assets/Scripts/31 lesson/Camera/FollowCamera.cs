using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Target;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Target.position;
    }

    void Update()
    {
        transform.position = new Vector3(
            Target.position.x + offset.x,
            Target.position.y + offset.y,
            Target.position.z + offset.z);
    }
}
