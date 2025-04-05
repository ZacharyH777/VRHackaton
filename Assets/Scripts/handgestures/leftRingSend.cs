using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftRingSend : MonoBehaviour
{
    void Awake()
    {
        Handcontroller.ringLeft = this.transform;
    }
}
