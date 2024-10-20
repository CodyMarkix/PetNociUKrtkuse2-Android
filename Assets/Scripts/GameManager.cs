using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Android;
using System;

public class GameManager : MonoBehaviour {
    public GameObject customnightmenu;
    public GameObject nightsixbutton;
    public GameObject nightsevenbutton;
    
    public SaveFileManager saveMgr;
    public InputAction action;

    [System.NonSerialized]
    public int night; // 0 = v main menu; 1 - 5 = noc    1 - 5

    // Start is called before the first frame update
    void Start() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0) {
            // We'll need this for saves because I've decided FUCK PlayerPrefs,
            // we're only using them to load the correct night
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            
            /*
            if (!PlayerPrefs.HasKey("night")) {
                SetUpPlayerPrefs();
            }
            */

        } else if (currentScene == 1) {
            // if (PlayerPrefs.GetInt("started") != 1) { PlayerPrefs.SetInt("started", 1); }

            action.Enable();
            action.performed += SwitchToTrailer;
            

            night = saveMgr.GetNight();
            // if (PlayerPrefs.GetInt("night") >= 6) { nightsixbutton.SetActive(true); }
            // if (PlayerPrefs.GetInt("night") >= 7) { nightsevenbutton.SetActive(true); }
            if (night >= 6) { nightsixbutton.SetActive(true); }
            if (night >= 7) { nightsevenbutton.SetActive(true); }

            customnightmenu.SetActive(false);
        }
    }

    void SwitchToTrailer(InputAction.CallbackContext context) {
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void QuitGame(InputAction.CallbackContext context) {
        saveMgr.SaveAll();
        Application.Quit();
    }

    [Obsolete("SetUpPlayerPrefs is obsolete and will be deleted soon, saves are now handled via SaveFileManager.")]
    void SetUpPlayerPrefs() {
        if (!PlayerPrefs.HasKey("night")) { PlayerPrefs.SetInt("night", 1); }
        PlayerPrefs.Save();
    }
}
