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
                    teksti.text = "Oh, did I forgot to tell you that you can't jump once you land on a golden block? Sorry about that...\n\nGot stuck? Press R key to respawn to last checkpoint.";
                    break;
                case "HelpBox_5":
                    teksti.text = "Tip: You can fly only for a second or so BUT have you noticed that the initial jump does not count? Try combining a long jump with a delayed start of the flight to cross longer distances.";
                    break;
                case "HelpBox_6":
                    int kuolemat = PlayerPrefs.GetInt("kuolemat");
                    if(kuolemat <= 0)
                    {
                        teksti.text = "Hooray!\n\nYou made it this far. And you did it without dying even once?!?\n\nContinue by jumping to the great unknown below.";
                    }
                    else if(kuolemat == 1)
                    {
                        teksti.text = "Hooray!\n\nYou made it this far.\n\nDuring you adventure you died one time. That's very good!\n\nThank you for playing this little demo.\n\nContinue by jumping to the great unknown below.";
                    }
                    else if(kuolemat >= 35)
                    {
                        teksti.text = "You finally made it this far.\n\nDuring you adventure you died " + kuolemat + " times. You're not a gamer, are you?\n\nContinue by jumping to the great unknown below.";
                    }
                    else if(kuolemat > 100)
                    {
                        teksti.text = "!?!\n\nYou made it this far but on the way you died over a hundred times...\n\nContinue by jumping to the great unknown below.";
                    }
                    else
                    {
                        teksti.text = "Hooray!\n\nYou made it this far. Thank you for playing this little demo.\n\nDuring you adventure you died " + PlayerPrefs.GetInt("kuolemat") + " times.\n\nContinue by jumping to the great unknown below.";
                    }
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
