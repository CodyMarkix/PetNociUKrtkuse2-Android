using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Tablet : MonoBehaviour {
    Dictionary<string, Vector3> camPosIndex = new Dictionary<string, Vector3> {
        {"Cam1A", new Vector3(-4.705235f, 2.883649f, -3.598674f) },
        {"Cam1B", new Vector3(-4.832236f, 3.139649f, -8.645674f) },
        {"Cam2A", new Vector3(0.6787641f, 2.584649f, -3.598674f) },
        {"Cam2B", new Vector3(0.3227642f, 3.139649f, -8.645674f) },
        {"Cam3A", new Vector3(3.064764f, 2.537649f, -4.676674f) },
        {"Cam4A", new Vector3(-2.281236f, 2.537649f, 6.388326f) },
        {"Cam5A", new Vector3(8.227764f, 2.537649f, 15.67833f) },
        {"Cam5B", new Vector3(1.367764f, 2.537649f, 14.62833f) },
        {"Cam6A", new Vector3(11.70876f, 2.537649f, 9.266326f) },
        {"Cam6B", new Vector3(19.41f, 12f, -17.3f) }
    };

    Dictionary<string, Vector3> camRotIndex = new Dictionary<string, Vector3>() {
        {"Cam1A", new Vector3(30.422f, -16.35f, 0f)},
        {"Cam1B", new Vector3(38.47f, 213.8f, 0f) },
        {"Cam2A", new Vector3(28.6f, 16.35f, 0f) },
        {"Cam2B", new Vector3(38.47f, -216.9f, 0f) },
        {"Cam3A", new Vector3(27.451f, 32.548f, -1.242f) },
        {"Cam4A", new Vector3(27.451f, -26.419f, -1.242f) },
        {"Cam5A", new Vector3(27.451f, 225f, -1.242f) },
        {"Cam5B", new Vector3(27.451f, 30.7f, -1.242f) },
        {"Cam6A", new Vector3(16.46f, 44.782f, -1.242f) },
        {"Cam6B", new Vector3(0f, 180f, 0f) }
    };

    public GameObject tabletScreen;
    public Transform securityCamera;
    public RenderTexture[] cameraMaterials;
    public AudioSource tabletOpenSFX;
    
    [System.NonSerialized]

    public bool isLooking = false;
    public string currentCam = "1B";

    public InputActionMap camKeys;


    void OnEnable() {
        camKeys.Enable();
        tabletScreen.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    void onDisable() {
        camKeys.Disable();
    }

    void Awake() {
    }

    public int PlayTabletToggle() {
        try {
            tabletOpenSFX.Play();
            return 0;

        } catch (System.Exception) {
            return 1;
        }
    }

    public void SwitchCam(string camera) {
        switch (camera) {
            case "Cam1A":
                securityCamera.position = camPosIndex["Cam1A"];
                securityCamera.eulerAngles = camRotIndex["Cam1A"];
                break;

            case "Cam1B":
                securityCamera.position = camPosIndex["Cam1B"];
                securityCamera.eulerAngles = camRotIndex["Cam1B"];
                break;

            case "Cam2A":
                securityCamera.position = camPosIndex["Cam2A"];
                securityCamera.eulerAngles = camRotIndex["Cam2A"];
                break;
            
            case "Cam2B":
                securityCamera.position = camPosIndex["Cam2B"];
                securityCamera.eulerAngles = camRotIndex["Cam2B"];
                break;

            case "Cam3A":
                securityCamera.position = camPosIndex["Cam3A"];
                securityCamera.eulerAngles = camRotIndex["Cam3A"];
                break;

            case "Cam4A":
                securityCamera.position = camPosIndex["Cam4A"];
                securityCamera.eulerAngles = camRotIndex["Cam4A"];
                break;
            
            case "Cam5A":
                securityCamera.position = camPosIndex["Cam5A"];
                securityCamera.eulerAngles = camRotIndex["Cam5A"];
                break;

            case "Cam5B":
                securityCamera.position = camPosIndex["Cam5B"];
                securityCamera.eulerAngles = camRotIndex["Cam5B"];
                break;

            case "Cam6A":
                securityCamera.position = camPosIndex["Cam6A"];
                securityCamera.eulerAngles = camRotIndex["Cam6A"];
                break;
            
            case "Cam6B":
                securityCamera.position = camPosIndex["Cam6B"];
                securityCamera.eulerAngles = camRotIndex["Cam6B"];
                break;
            
        }
    }

    public void Cam1A() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[0];
    }

    public void Cam1B() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[1];
    }

    public void Cam2A() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[2];
    }

    public void Cam2B() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[3];
    }

    public void Cam3A() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[4];
    }

    public void Cam4A() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[5];
    }

    public void Cam5A() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[6];
    }

    public void Cam5B() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[7];
    }

    public void Cam6A() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[8];
    }

    public void Cam6B() {
        tabletScreen.GetComponentInChildren<RawImage>().texture = cameraMaterials[9];
    }

}

