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
                    teksti.text = "Watch out for those nasty spikes! Touching them is probably a bad idea...\n\nOr what do I know, I'm just some random text.";
                    break;
                case "HelpBox_3":
                    teksti.text = "Well, this is a problem. If only could you fly... Maybe try double tapping the spacabar.\n\n(First jump, then jump again but keep the button pressed.)";
                    break;
                case "HelpBox_4":
                    teksti.text = "Oh, did I forgot to tell you that you can't jump when standing on a golden block? Sorry about that...\n\nGot stuck? Press R key to respawn to last checkpoint.";
                    break;
                case "HelpBox_5":
                    teksti.text = "Tip: You can stay flying only for a second or so BUT have you noticed that the timer does not count the initial jump? Try combining long jump to a delayed start of the flight to cross longer distances.";
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
