using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Hero : MonoBehaviour {

    public GameObject kamera;
    public float speed;
    public float jumpForceX;
    public float jumpForceY;
    public float cameraOffsetY;

    public bool paused = false;

    private Transform transformi;
    private Transform kameranTansform;
    private SpriteRenderer sp;
    private Animator animaattori;
    private Rigidbody2D rb;
    private bool ilmassa = false;

	// Use this for initialization
	void Start () {
        transformi = this.GetComponent<Transform>();
        kameranTansform = kamera.GetComponent<Transform>();
        sp = this.GetComponent<SpriteRenderer>();
        animaattori = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && !ilmassa)
            {
                Vector2 force = new Vector2(jumpForceX, jumpForceY);
                animaattori.SetInteger("Tila", 2);
                rb.AddForce(force);
                ilmassa = true;
            }
        }
        else
        {
            animaattori.SetInteger("Tila",0);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
                ilmassa = false;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "YouDie":
                YouDie();
                break;
        }
    }

    private void FixedUpdate()
    {
        if (!paused)
        {
            if (Input.GetKey(KeyCode.D))
            {
                sp.flipX = false;
                if (!ilmassa)
                {
                    animaattori.SetInteger("Tila", 1);
                }
                transformi.Translate(speed, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                sp.flipX = true;
                if (!ilmassa)
                {
                    animaattori.SetInteger("Tila", 1);
                }
                transformi.Translate(-speed, 0f, 0f);
            }
            else if (!ilmassa)
            {
                animaattori.SetInteger("Tila", 0);
            }

            // Laitetaan kamera seuraamaan pelaajaa
            Vector3 kameranUusiPosition = kameranTansform.position;

            kameranUusiPosition.x = transformi.position.x;
            kameranUusiPosition.y = transformi.position.y + cameraOffsetY;

            if (kameranUusiPosition.x < -11f)
            {
                kameranUusiPosition.x = -11f;
            }
            else if (kameranUusiPosition.x > 11f)
            {
                kameranUusiPosition.x = 11f;
            }
            if (kameranUusiPosition.y < -4.8f)
            {
                kameranUusiPosition.y = -4.8f;
            }
            else if (kameranUusiPosition.y > 5f)
            {
                kameranUusiPosition.y = 5f;
            }

            kameranTansform.position = kameranUusiPosition;
        }
    }

    // Handlataan pelaajan kuoleminen
    private void YouDie()
    {
        this.GetComponent<AudioSource>().Play();
        transformi.position = new Vector3(-13.6f,-5.5f);
    }
}
