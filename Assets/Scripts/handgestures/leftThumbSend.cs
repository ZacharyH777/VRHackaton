using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftThumbSend : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Handcontroller.thumbLeft = this.transform;
    }
}
