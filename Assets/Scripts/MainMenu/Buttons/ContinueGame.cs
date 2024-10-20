using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour {
    public SaveFileManager saveMgr;
    
    public void OnButtonPress() {
        if (saveMgr.GetNight() == 0) {
            saveMgr.SetNight(1);
        }

        if (saveMgr.GetNight() <= 5) {
            SceneManager.LoadScene(saveMgr.GetNight() + 1);
            Debug.Log(saveMgr.GetNight());
        } else {
            saveMgr.SaveAll();
            SceneManager.LoadScene(6); // Night 5 scene
        }
    }
}
