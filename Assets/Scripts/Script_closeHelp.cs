using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_closeHelp : MonoBehaviour {

    private Script_Hero playerScript;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Script_Hero>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            playerScript.paused = false;
        }
	}
}
