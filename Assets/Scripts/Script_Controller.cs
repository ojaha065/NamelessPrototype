using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Controller : MonoBehaviour {

    public GameObject triggerBoss;

    public GameObject theBoss;

    private Script_Trigger triggerBossScript;
    private bool triggerBossDone = false;

	// Use this for initialization
	void Start () {
        triggerBossScript = triggerBoss.GetComponent<Script_Trigger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
    }

}
