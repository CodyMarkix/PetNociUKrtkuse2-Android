using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {   
    public Newspaper paperscript;
    public SaveFileManager saveMgr;
    
    public void OnButtonPress() {
        saveMgr.SetNight(1);
        paperscript.gameObject.SetActive(true);
        paperscript.ShowPaper();
    }
}
