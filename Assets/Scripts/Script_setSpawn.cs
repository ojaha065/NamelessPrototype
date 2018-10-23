using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_setSpawn : MonoBehaviour {

    private Transform transformi;

    private bool activated = false;

	// Use this for initialization
	void Start () {
        transformi = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (!activated)
        {
            transformi.Rotate(0f, 0f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !activated)
        {
            activated = true;
            this.GetComponent<AudioSource>().Play();
            transformi.rotation = Quaternion.identity;
        }
    }
}
