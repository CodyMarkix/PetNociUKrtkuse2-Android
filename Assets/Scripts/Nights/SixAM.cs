using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class SixAM : MonoBehaviour {
    public AudioSource endNightSound;
    public GameObject endNightPanel;
    public SaveFileManager saveMgr;

    [Header("Animatronics")]
    public Krtkus krtkusak;
    public Myskus myskusak;
    public Zajic zajac;

    public InputActionMap map;
    System.Random rng = new System.Random();

    List<string> alphabet = new List<string>();

    void Awake() {
        map.Enable();
        map.FindAction("SkipNight").performed += EndNightKeybind;
    }

    void Start() {
        for (char c = 'A'; c <= 'Z'; c++) {
            alphabet.Add("" + c);
        }
        for (char i = '0'; i <= '9'; i++) {
            alphabet.Add("" + i);
        }

    }

    public void EndNightKeybind(InputAction.CallbackContext context) {
        if (Debug.isDebugBuild) {
            EndNight();
        }
    }

    public void EndNight() {
        krtkusak.enabled = false;
        myskusak.enabled = false;
        zajac.enabled = false;

        endNightPanel.SetActive(true);
        endNightSound.Play();
        StartCoroutine(SwitchNextNight());
    }

    IEnumerator SwitchNextNight() {
        int currentNight = saveMgr.GetNight();
        int nextNight = currentNight + 1;

        // Debug.Log(string.Format("Current scene: {0}; Next scene: {1} Current night: {2}; Next night: {3}", scene, nextScene, currentNight, nextNight));

        StartCoroutine(SetRandomNumbers());
        yield return new WaitForSeconds(10f);
        if (currentNight < 5 && currentNight > 0 ) {
            // Načte další noc
            saveMgr.SetNight(nextNight);

            saveMgr.SaveAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else if (currentNight == 5) {
            // Načte victory scénu
            saveMgr.SetNight(nextNight);

            saveMgr.SaveAll();
            SceneManager.LoadScene(4);
        } else if (currentNight == 6 || currentNight == 7) {
            // Načte main menu
            if (currentNight == 6) {
                if (saveMgr.GetNight() == 6) {
                    saveMgr.SetNight(nextNight);
                }
            } else if (currentNight == 7) {
                // Give 3rd star to player
                if (krtkusak.AILevel == 20 && myskusak.AILevel == 20 && zajac.AILevel == 20) {
                    saveMgr.SetNight(currentNight + 1); // Scene should be equal to 8 at that moment
                }
            }

            saveMgr.SaveAll();
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator SetRandomNumbers() {
        int iterator = 1;
        while (true) {
            yield return new WaitForSeconds(0.25f);
            endNightPanel.GetComponentInChildren<TMP_Text>().text = string.Format("{0} {1}{2}",
                                                                        alphabet[rng.Next(0, alphabet.Count - 1)],
                                                                        alphabet[rng.Next(0, alphabet.Count - 1)],
                                                                        alphabet[rng.Next(0, alphabet.Count - 1)]
                                                                    );
            if (iterator == 17) {
                break;
            } else {
                iterator++;
            }
        }

        endNightPanel.GetComponentInChildren<TMP_Text>().text = string.Format("6 AM");
    }
}