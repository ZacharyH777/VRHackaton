using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTheBall : MonoBehaviour
{
    private Rigidbody rb;
    private RayCastForGroundType groundType;
    private float rotationForce = 1;

    public Transform cameraRot;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        groundType = this.GetComponent<RayCastForGroundType>();
    }

    void FixedUpdate()
    {

        float speedMultiplier;
        Vector3 forward = cameraRot.transform.forward;

        Vector3 newforward = forward.normalized;

        forward[1] = 0f;
        newforward[1] = 0f;

        speedMultiplier = Mathf.Clamp( Mathf.Abs(newforward.z * rb.velocity.z / 10f) + Mathf.Abs(newforward.x * rb.velocity.x / 10f) + 1, -15.5f, 15.5f);

        if (Handcontroller.palmLeft != null && Handcontroller.palmRight != null)
        {
            Quaternion inverseCameraRotation = Quaternion.Inverse(cameraRot.rotation);
            Vector3 rightHand = inverseCameraRotation * Handcontroller.palmRight.position;
            Vector3 leftHand = inverseCameraRotation * Handcontroller.palmLeft.position;
            
            // Calculate speed based on the distance between hand controllers along the z-axis
            float distance = Mathf.Abs(rightHand.z - leftHand.z);
            float speed = Mathf.Clamp(distance * 600f, -90f, 90f);
            //Debug.Log("Direction: " + speed);

            // Determine the force direction based on the relative positions of hand controllers along the z-axis
            float direction = Mathf.Sign(rightHand.z - leftHand.z);

            // Calculate friction based on current velocity along the z-axis
            float friction = Mathf.Clamp01(1f - ( Mathf.Abs(newforward.z * rb.velocity.z / 20f) + Mathf.Abs(newforward.x * rb.velocity.x / 20f)));

            float normalForceY;
            if(!groundType.onGround)
            {
                speed = speed/5;
                normalForceY = .1f;
            }
            else
            {
                int directionMult;
                if(rb.velocity.x < 0 || rb.velocity.z < 0)
                {
                    directionMult = -1;
                }
                else
                {
                    directionMult = 1;
                }
                normalForceY = Mathf.Abs((1.3f + (10 * groundType.getNormalForceMultiplierY())) * groundType.getNormalForceMultiplierY()) + .1f;
            }
            Debug.Log(normalForceY);
            rb.AddForce(Vector3.down * 400f * normalForceY, ForceMode.Force);
            // Add force to the ball with increased speed along the z-axis
            rb.AddForce(forward * direction * speedMultiplier * speed * friction * 4f, ForceMode.Force);
        }
    }
}
