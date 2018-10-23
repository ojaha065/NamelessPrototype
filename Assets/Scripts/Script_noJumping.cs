using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_noJumping : MonoBehaviour {

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
            playerScript.noJumping = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerScript.noJumping = false;
        }
    }
}
