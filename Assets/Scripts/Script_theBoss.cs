using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_theBoss : MonoBehaviour {

    private Transform transformi;
    private HingeJoint2D theHinge;

	// Use this for initialization
	void Start () {
        theHinge = this.GetComponent<HingeJoint2D>(); // Haetaan liitos
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        JointMotor2D theMotor = theHinge.motor; // Haetaan liitoksen moottori
        float uusiMotorSpeed = theMotor.motorSpeed + Random.Range(-1,5); // Lasketaan uusi moottorin nopeus

        // Estetään extreme-tilanteet
        if(uusiMotorSpeed <= 0 || uusiMotorSpeed > 300)
        {
            uusiMotorSpeed = 100;
        }

        theMotor.motorSpeed = uusiMotorSpeed; // Liitetään nopeus moottoriin
        theHinge.motor = theMotor; // Liitetään muutettu moottori liitokseen
    }
}
