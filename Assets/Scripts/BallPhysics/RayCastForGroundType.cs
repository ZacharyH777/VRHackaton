using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForGroundType : MonoBehaviour
{
    public bool onGround = false;
    private float rotationOfSlopeZ;
    private float rotationOfSlopeX;
    private float rotationOfSlopeY;

    // Update is called once per frame
    void Update()
    {

        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;


        if (Physics.SphereCast(new Vector3(transform.position.x, transform.position.y + .52f, transform.position.z), .01f , Vector3.down, out hit, 1.11f, layerMask))
        {
            Debug.DrawRay(transform.position, Vector3.down * .65f, Color.green);
            onGround = true;
            rotationOfSlopeZ = (float)hit.transform.forward.z;
            rotationOfSlopeX = (float)hit.transform.forward.x;
            rotationOfSlopeY = (float)hit.transform.forward.y;
            Debug.Log(hit.transform.forward.y);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * .55f, Color.red);
            onGround = false;
            rotationOfSlopeZ = 0f;
            rotationOfSlopeX = 0f;
            rotationOfSlopeY = 0f;
        }
    }
    public float getNormalForceMultiplierY()
    {
        return Mathf.Abs(rotationOfSlopeY);
    }

    public float getNormalForceMultiplierX()
    {
        return (rotationOfSlopeX) * rotationOfSlopeY;
    }
}
