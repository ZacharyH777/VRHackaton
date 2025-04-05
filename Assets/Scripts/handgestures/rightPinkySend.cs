using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPinkySend : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Handcontroller.pinkyRight = this.transform;
    }
}
