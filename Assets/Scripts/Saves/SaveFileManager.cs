using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFileManager : MonoBehaviour {
    [System.NonSerialized]
    public UtilityFuncs utilFuncs = new UtilityFuncs();
    public SaveFile save;

    string[] saveFilePaths;
    string selectedSaveSlotPath;
    
    [System.NonSerialized]
    public int selectedSaveSlot;

    void Awake() {
        selectedSaveSlotPath = Application.persistentDataPath + "/selectedSave.dat";
        saveFilePaths = new string[3] { 
            Application.persistentDataPath + "/save0.json",
            Application.persistentDataPath + "/save1.json",
            Application.persistentDataPath + "/save2.json"
        };

        if (SceneManager.GetActiveScene().name == "IntroWarning") { // IntroWarning.unity
            if (File.Exists(selectedSaveSlotPath)) {
                save = new SaveFile(1, 0, 0);

                string sSSPRaw = File.ReadAllText(selectedSaveSlotPath);
                selectedSaveSlot = int.Parse(sSSPRaw);
                if (selectedSaveSlot > 2) { Application.Quit(128); }

                if (!File.Exists(saveFilePaths[selectedSaveSlot])) {
                    string freshSaveText = JsonConvert.SerializeObject(save);

                    FileStream saveFile = File.Create(saveFilePaths[selectedSaveSlot]);
                    using (StreamWriter writer = new StreamWriter(saveFile)) {
                        writer.Write(freshSaveText);
                    }
                    saveFile.Close();
                }
                
            } else {
                FileStream saveSlotFile = File.Create(selectedSaveSlotPath);
                using (StreamWriter writer = new StreamWriter(saveSlotFile)) {
                    writer.Write("0");
                }
                saveSlotFile.Close();
                Awake(); // recursion baybyyyyy
            }
        } else {
            byte[] sSSRRead = File.ReadAllBytes(selectedSaveSlotPath);
            string index = System.Text.Encoding.Default.GetString(sSSRRead);
            selectedSaveSlot = int.Parse(index);

            string selectedSaveText = File.ReadAllText(saveFilePaths[selectedSaveSlot]);
            PlayerPrefs.SetString("save", selectedSaveText);

            save = JsonConvert.DeserializeObject<SaveFile>(selectedSaveText);
        }
    }

    void Start() {
        Debug.Log(string.Format("LOADED SAVE VALUES: Night: {0}; Started: {1}; BadStars: {2}", GetNight(), GetStarted(), GetBadStars()));
    }

    public int GetNight() {
        return save.night;
    }

    public void SetNight(int night) {
        if (night > 0 & night < 8) {
            save.night = night;
            PlayerPrefs.SetInt("night", save.night);
        }
    }

    public int GetStarted() {
        return save.started;
    }

    public void SetStarted(int start) {
        save.started = start;
        PlayerPrefs.SetInt("started", save.started);
    }

    public void ToggleStarted() {
        if (save.started == 0) {
            save.started = 1;
        } else {
            save.started = 0;
        }

        PlayerPrefs.SetInt("started", save.started);
    }

    public int GetBadStars() {
        return save.badStars;
    }

    public void ToggleBadStars() {
        if (save.badStars == 0) {
            save.badStars = 1;
        } else {
            save.badStars = 0;
        }

        PlayerPrefs.SetInt("badStars", save.badStars);
    }

    public void SaveAll() {
        File.WriteAllText(saveFilePaths[selectedSaveSlot], JsonConvert.SerializeObject(save));
    }
    
    void OnApplicationQuit() {
        SaveAll();
    }

    void OnApplicationFocus() {
        if (Application.platform == RuntimePlatform.Android) {
            SaveAll();
        }
    }
}