﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tämä on yleiskäyttöinen koodi joka liitetään kaikkiin triggereihin.
public class Script_Trigger : MonoBehaviour {

    public bool triggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
