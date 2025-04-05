using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPalmSend : MonoBehaviour
{
    void Awake()
    {
        Handcontroller.palmRight = this.transform;
    }
}
