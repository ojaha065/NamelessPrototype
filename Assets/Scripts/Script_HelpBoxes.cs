using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_HelpBoxes : MonoBehaviour {

    public GameObject panel;
    public GameObject helpText;

    private Script_Hero playerScript;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Script_Hero>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerScript.paused = true;
            Text teksti = helpText.GetComponent<Text>();
            switch (this.tag)
            {
                case "HelpBox_1":
                    teksti.text = "Move your character using the WASD keys. Jump using Space (or W).\n\nOh, you probably already knew that, huh?";
                    break;
                case "HelpBox_2":
                    teksti.text = "Watch out for those nasty spikes! Touching them is probably bad...\n\nOr what do I know, I'm just some random text.";
                    break;
                default:
                    Debug.LogError("Jokin men nyt pieleen!");
                    break;
            }
            panel.SetActive(true);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.LogWarning("Helppilaatikko törmäsi johonkin muuhun kuin pelaajaan.");
        }
    }
}
