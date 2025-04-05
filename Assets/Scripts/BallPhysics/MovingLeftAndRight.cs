using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftAndRight : MonoBehaviour
{
    private Rigidbody rb;
    private RayCastForGroundType groundType;
    private float rotationForce = 1;

    public Transform cameraRot;

    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        groundType = this.GetComponent<RayCastForGroundType>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float speedMultiplier;

        Vector3 right = cameraRot.transform.right;

        Vector3 newforward = right.normalized;
        right[1] = 0f;
        newforward[1] = 0f;

        speedMultiplier = Mathf.Clamp(newforward.z * Mathf.Abs(rb.velocity.z / 10f) + newforward.x * Mathf.Abs(rb.velocity.x / 10f) + 1, -15.5f, 15.5f);

        if (Handcontroller.palmLeft != null && Handcontroller.palmRight != null)
        {
            Quaternion inverseCameraRotation = Quaternion.Inverse(cameraRot.rotation);
            Vector3 rightHand = Handcontroller.palmRight.position;
            Vector3 leftHand = Handcontroller.palmLeft.position;
            // Calculate speed based on the distance between hand controllers
            float distance = Mathf.Abs(leftHand.y - rightHand.y);
            float speed = Mathf.Clamp(distance * 350f, -90f, 90f);
            //Debug.Log("Direction: " + speed);

             if(!groundType.onGround)
            {
                speed = speed/5;
            }

            // Determine the force direction based on the relative positions of hand controllers
            float direction = Mathf.Sign(leftHand.y - rightHand.y);

            // Calculate friction based on current velocity
            float friction = Mathf.Clamp01(1f - ( newforward.z * Mathf.Abs(rb.velocity.z / 15f) + newforward.x * Mathf.Abs(rb.velocity.x / 15f)));
            rb.AddForce( right * direction * speedMultiplier * speed * friction * 4f, ForceMode.Force);
        }
    }
}
