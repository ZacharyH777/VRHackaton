using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target; // The target object to orbit around
    public Rigidbody targetRigidbody; // The Rigidbody of the target object
    public float orbitSpeedMultiplier = 2.0f; // Speed multiplier based on object's velocity
    public float rotationDamping = 0.1f; // Damping for smooth rotation
    private float offset = -3f; // Offset from the target object
    private Vector3 finalRotPosition;

    private Vector3 previousPosition;

    void Start()
    {
        // Initialize previous position with the initial position of the target
        previousPosition = targetRigidbody.position;
        this.transform.position = new Vector3(target.position.x, target.position.y + 3, target.position.z - 7);
    }

    void Update()
    {

        Vector3 pV = Vector3.zero;

        Vector3 CamerPos = this.transform.forward.normalized * offset;
        CamerPos[1] = 0;

        pV = targetRigidbody.velocity.normalized * offset;
        finalRotPosition = new Vector3(pV.x + target.position.x, target.position.y + 3, pV.z + target.position.z) + (CamerPos); 
        float distanceFollow = Mathf.Abs(target.position.z - transform.position.z) + Mathf.Abs(target.position.y - transform.position.y) + Mathf.Abs(target.position.x - transform.position.x);
        if(finalRotPosition != null)
            transform.position = Vector3.Lerp(transform.position, finalRotPosition, Time.deltaTime * orbitSpeedMultiplier);

        transform.LookAt(target.position);
    }

    public void setTarget(Transform t)
    {
        target = t;
    }
}