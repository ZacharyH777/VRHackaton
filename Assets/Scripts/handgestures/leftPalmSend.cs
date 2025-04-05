using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftPalmSend : MonoBehaviour
{
    void Awake()
    {
        Handcontroller.palmLeft = this.transform;
    }
}
