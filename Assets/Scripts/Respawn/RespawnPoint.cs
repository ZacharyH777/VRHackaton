using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        if(other.gameObject != null && other.gameObject.CompareTag("Player")) {
            Transform getRot = Camera.main.transform.parent.parent;
            RotateCamera rotCam = getRot.gameObject.GetComponent<RotateCamera>();
            rotCam.setTarget(this.transform.parent);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = this.transform.parent.position;
            other.gameObject.SetActive(false);
            StartCoroutine(WaitAndFinish(other, rotCam));
        }
    }

    IEnumerator WaitAndFinish(Collider other, RotateCamera rotateCamera)
    {
        yield return new WaitForSeconds(1.5f);
        other.gameObject.SetActive(true);
        rotateCamera.setTarget(other.transform);
    }
}
