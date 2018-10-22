using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Hero : MonoBehaviour {

    public GameObject kamera;
    public float speed;
    public float jumpForceX;
    public float jumpForceY;
    public float boostButtonForce;
    public float cameraOffsetY;
    public float lentoAika;

    public bool paused = false;

    private Transform transformi;
    private Transform kameranTansform;
    private SpriteRenderer sp;
    private Animator animaattori;
    private Rigidbody2D rb;
    private AudioSource jumpSound;

    // Lentäminen
    private bool ilmassa = false;
    private bool allowFlight = false;
    private bool weAreJumping = false;
    private float aloitusKorkeus = -1;
    private float lopetusAika = -1;

	// Use this for initialization
	void Start () {
        transformi = this.GetComponent<Transform>();
        kameranTansform = kamera.GetComponent<Transform>();
        sp = this.GetComponent<SpriteRenderer>();
        animaattori = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        jumpSound = this.GetComponents<AudioSource>()[1];
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && !ilmassa)
            {
                jumpSound.Play();
                Vector2 force = new Vector2(jumpForceX, jumpForceY);
                animaattori.SetInteger("Tila", 2);
                rb.AddForce(force);
                ilmassa = true;
                allowFlight = false; // Lento ei saa alkaa samalla painalluksella
                weAreJumping = true;
            }
            else if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W)) && weAreJumping)
            {
                allowFlight = true;
                weAreJumping = false; // Muutetaan hyppy lentämiseksi
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
                weAreJumping = false;
                allowFlight = false;
                aloitusKorkeus = -1;
                lopetusAika = -1;
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
            case "BoostButton":
                ilmassa = true;
                rb.AddForce(new Vector2(0f, boostButtonForce));
                break;
            default:
                Debug.LogWarning("Pelaaja törmäsi triggeriin jolle ei ole käsittelijää.");
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
            else if(ilmassa && !weAreJumping && !allowFlight)
            {
                animaattori.SetInteger("Tila", 3);
            }
            else if (!ilmassa)
            {
                animaattori.SetInteger("Tila", 0);
                if(Random.Range(1,50) == 1)
                {
                    animaattori.SetInteger("Tila_Idle", Random.Range(0, 3));
                }
            }

            // Lentäminen
            if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && allowFlight)
            {
                // Tallennetaan lennon aloituskorkeus- ja aika, jolloin lento viimeistään katkaistaan.
                if (aloitusKorkeus == -1)
                {
                    aloitusKorkeus = transformi.position.y;
                    lopetusAika = Time.time + lentoAika; // Time.time pitää kirjaa ajasta sekunteina pelin alusta.
                }
                if(transformi.position.y < aloitusKorkeus && Time.time < lopetusAika)
                {
                    rb.AddForce(new Vector2(0f, 25f));
                }
                else if(Time.time >= lopetusAika)
                {
                    allowFlight = false;
                    aloitusKorkeus = -1;
                    lopetusAika = -1;
                }
            }
            {

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
        this.GetComponents<AudioSource>()[0].Play();
        transformi.position = new Vector3(-13.6f,-5.5f);
    }
}
