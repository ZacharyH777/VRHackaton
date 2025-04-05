using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftPinkySend : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Handcontroller.pinkyLeft = this.transform;
    }
}
