using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_Controller : MonoBehaviour {

    public GameObject triggerBoss;
    public GameObject triggerTheEnd;

    public GameObject theBoss;

    public GameObject FPS_Panel;
    public GameObject GO_FPS_text;

    private Script_Trigger triggerBossScript;
    private bool triggerBossDone = false;
    private Script_Trigger triggerTheEndScript;

    // FPS-laskuri
    private bool FPSCounterOn = false;
    private float FPS = 0f;
    private Text FPS_text;

	// Use this for initialization
	void Start () {
        triggerBossScript = triggerBoss.GetComponent<Script_Trigger>();
        triggerTheEndScript = triggerTheEnd.GetComponent<Script_Trigger>();
        FPS_text = GO_FPS_text.GetComponent<Text>();

        PlayerPrefs.SetInt("kuolemat", 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // FPS-laskuri
        if (Input.GetKeyDown(KeyCode.F))
        {
            FPSCounterOn = !FPSCounterOn; // true --> false, false --> true
            FPS_Panel.SetActive(FPSCounterOn);

        }
        if (FPSCounterOn)
        {
            FPS = 1 / Time.smoothDeltaTime;
            FPS_text.text = FPS.ToString("0");
        }

	}

    private void FixedUpdate()
    {
        if (!triggerBossDone && triggerBossScript.triggered)
        {
            AudioSource[] apu = this.GetComponents<AudioSource>();
            apu[0].Stop();
            apu[1].Play();
            theBoss.SetActive(true);
            triggerBossDone = true;
        }
        else if (triggerTheEndScript.triggered)
        {
            SceneManager.LoadScene("Scene_theEnd");
        }
    }

}
