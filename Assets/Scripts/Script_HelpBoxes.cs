using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_HelpBoxes : MonoBehaviour {

    public GameObject panel;
    public GameObject helpText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Text teksti = helpText.GetComponent<Text>();
            switch (this.tag)
            {
                case "HelpBox_1":
                    teksti.text = "Move your character using the WASD keys. Jump using Space (or W).\n\nOh, you probably already know that, huh?";
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
