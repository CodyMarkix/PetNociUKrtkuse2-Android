using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class ResLightManager : MonoBehaviour {
    public GameObject[] lights;

    [Header("External scripts")]
    public Tablet tabletScript;
    public Battery batteryScript;

    [Header("Input")]
    public InputAction toggleLightInput;

    [System.NonSerialized]
    public bool hasToggledLights = false;

    private bool lastRememberedState = false;
    
    void Awake() {
        toggleLightInput.started += EnableLight;
        toggleLightInput.canceled += DisableLight;
    }

    void Update() {
        if (lastRememberedState != tabletScript.isLooking) {
            if (tabletScript.isLooking) {
                toggleLightInput.Enable();
            } else {
                toggleLightInput.Disable();
            }

            lastRememberedState = tabletScript.isLooking;
        }

        if (tabletScript.isLooking) {
            if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count == 0) {
                if (hasToggledLights) {
                    // DisableLightInternal();
                }
            } else {
                foreach (var x in Touchscreen.current.touches) {
                    float xValue = x.position.x.ReadValue();
                    float yValue = x.position.y.ReadValue();
                    if (160f <= xValue && xValue <= 1126f) {
                        if (!hasToggledLights) {
                            // EnableLightInternal();
                        }
                    }
                }
            }

        }
        // Debug.Log(string.Format("X: {0}, Y: {1}", Touchscreen.current.primaryTouch.position.x.ReadValue(), Touchscreen.current.primaryTouch.position.y.ReadValue()));
    }

    void EnableLight(InputAction.CallbackContext context) {
        switch (tabletScript.currentCam) {
            case "Cam1A":
                lights[0].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam1B":
                lights[1].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam2A":
                lights[2].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam2B":
                lights[3].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam3A":
                lights[4].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam4A":
                lights[5].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam5A":
                lights[6].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam5B":
                lights[7].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;

            case "Cam6A":
                lights[8].SetActive(true);
                hasToggledLights = true;
                batteryScript.dischargeFloat = batteryScript.dischargeFloat + 750f; // 0.6f
                break;
        }
    }

    void DisableLight(InputAction.CallbackContext context) {
        batteryScript.dischargeFloat = batteryScript.dischargeFloat - 750f; // 0.6f
        hasToggledLights = false;
        foreach (GameObject x in lights) {
            x.SetActive(false);
        }
    }
}
