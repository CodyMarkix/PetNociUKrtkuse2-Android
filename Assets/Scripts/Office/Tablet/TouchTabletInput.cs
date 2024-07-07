using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTabletInput : MonoBehaviour
{
    [System.NonSerialized]
    public bool hasTouchedScreen;

    void OnMouseEnter() {
        hasTouchedScreen = true;
    }

    void OnMouseExit() {
        hasTouchedScreen = false;
    }
}
