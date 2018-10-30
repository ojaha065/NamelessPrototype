using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Credits : MonoBehaviour
{

    public float creditsSpeed;
    public GameObject panel;

    private Transform transformi;

    // Use this for initialization
    void Start()
    {
        transformi = panel.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Rullataan lopputekstejä ylös
        if (true) // Tässä pitäisi pysäyttää rullaaminen kun kaikki tekstit on rullattu.
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transformi.Translate(0f, creditsSpeed * 3, 0f);
            }
            else
            {
                transformi.Translate(0f, creditsSpeed, 0f);
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}