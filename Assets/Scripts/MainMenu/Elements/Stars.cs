using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stars : MonoBehaviour {
    public GameObject[] badStarsArr;
    public GameObject[] starsArr;

    private GameObject[][] spriteArrays;
    private int arrayPtr;

    public SaveFileManager saveMgr;
    public InputActionMap map;

    void Awake() {
        spriteArrays = new GameObject[][] {starsArr, badStarsArr};
        arrayPtr = saveMgr.GetBadStars() | 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        map.Enable();
        map.FindAction("toggleSprites").performed += toggleSprites;

        // Promiň
        // PlayerPrefs.SetInt("badStars", 0);
        // PlayerPrefs.Save();
        renderSprites();
    }

    void toggleSprites(InputAction.CallbackContext context) {
        /*
        if (PlayerPrefs.GetInt("badStars") == 1) {
            PlayerPrefs.SetInt("badStars", 0);
            arrayPtr = 0;
        } else {
            PlayerPrefs.SetInt("badStars", 1);
            arrayPtr = 1;
        }
        PlayerPrefs.Save();
        */
        saveMgr.ToggleBadStars();
        
        renderSprites();
    }

    void renderSprites() {
        foreach (GameObject x in badStarsArr) {
            x.SetActive(false);
        }
        
        foreach (GameObject y in starsArr) {
            y.SetActive(false);
        }

        switch (saveMgr.GetNight()) {
            case 6:
                if (saveMgr.GetBadStars() == 1) {
                    spriteArrays[arrayPtr][0].SetActive(true);
                } else {
                    spriteArrays[arrayPtr][0].SetActive(true);
                }
                break;

            case 7:
                if (saveMgr.GetBadStars() == 1) {
                    spriteArrays[arrayPtr][0].SetActive(true);
                    spriteArrays[arrayPtr][1].SetActive(true);
                } else {
                    spriteArrays[arrayPtr][0].SetActive(true);
                    spriteArrays[arrayPtr][1].SetActive(true);
                }
                break;

            case 8:
                if (saveMgr.GetBadStars() == 1) {
                    spriteArrays[arrayPtr][0].SetActive(true);
                    spriteArrays[arrayPtr][1].SetActive(true);
                    spriteArrays[arrayPtr][2].SetActive(true);
                } else {
                    spriteArrays[arrayPtr][0].SetActive(true);
                    spriteArrays[arrayPtr][1].SetActive(true);
                    spriteArrays[arrayPtr][2].SetActive(true);
                }
                break;

            default:
                break;
        }
    }
}
