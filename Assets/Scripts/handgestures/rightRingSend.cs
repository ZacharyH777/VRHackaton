using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightRingSend : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Handcontroller.ringRight = this.transform;
    }
}
