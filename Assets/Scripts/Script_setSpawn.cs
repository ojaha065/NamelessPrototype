using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_setSpawn : MonoBehaviour {

    public Text checkpointText;

    private Transform transformi;

    private bool activated = false;
    private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
        transformi = this.GetComponent<Transform>();
        originalPosition = checkpointText.gameObject.transform.position;
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
        else if (checkpointText.gameObject.activeSelf)
        {
            checkpointText.gameObject.GetComponent<Transform>().Translate(0f, -2f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !activated)
        {
            activated = true;
            checkpointText.gameObject.SetActive(true);
            checkpointText.gameObject.GetComponent<Transform>().position = originalPosition;
            this.GetComponent<AudioSource>().Play();
            transformi.rotation = Quaternion.identity;
        }
    }
}
