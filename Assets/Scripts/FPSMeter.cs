using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMeter : MonoBehaviour
{
    void FixedUpdate() {
        Debug.LogWarning(string.Format("FPS: {0}", 1.0f / Time.deltaTime));
    }
}
