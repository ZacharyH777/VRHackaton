using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightThumbSend : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Handcontroller.thumbRight = this.transform;
    }
}
