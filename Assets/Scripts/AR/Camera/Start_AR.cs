using UnityEngine;
using UnityEngine.XR;
using Meta.XR;

public class EnablePassthrough : MonoBehaviour
{
    void Start()
    {
        OVRManager.instance.isInsightPassthroughEnabled = true;
    }
}