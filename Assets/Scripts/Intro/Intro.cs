using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
    public SaveFileManager saveMgr;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SwitchToMenu());
    }

    IEnumerator SwitchToMenu() {
        yield return new WaitForSeconds(58.123f);
        Debug.Log("Audio played");
        
        saveMgr.SetStarted(1);
        saveMgr.SaveAll();

        SceneManager.LoadScene(1);
    }
}
