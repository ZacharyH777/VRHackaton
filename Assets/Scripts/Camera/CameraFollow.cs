using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform sphere;
    void LateUpdate()
    {
        this.transform.position = new Vector3(sphere.position.x, sphere.position.y + 3, sphere.position.z - 7);
    }
}
