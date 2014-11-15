using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float velocity;
    private float chargeVelocity;
    private float chargeTime;
    private float currentChargeTime;
    private float chargeCooldown;
    private bool hasChocolate;
    private float acceleration;
    private float accelerationMultiplier;
    private float maxSpeed;
    private Vector3 moveDir;

    private bool isCharging;

    private float currentChargeCooldown;

    private int score;

	// Use this for initialization
	void Start () {
        velocity = 500.0f;
        chargeVelocity = 2000.0f;
        chargeTime = 0.25f;
        currentChargeTime = chargeTime;
        chargeCooldown = 5.0f;
        currentChargeCooldown = 5.0f;
        maxSpeed = 50.0f;
        acceleration = 0.0f;
        accelerationMultiplier = 0.5f;
        score = 0;
        hasChocolate = false;
        isCharging = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentChargeTime);
        currentChargeCooldown -= Time.deltaTime;

        if (!isCharging)
        {
            moveDir = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDir += Vector3.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDir += Vector3.back;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDir += Vector3.right;
        }

        if (isCharging)
        {
            currentChargeTime -= Time.deltaTime;

            if (currentChargeTime <= 0.0f)
            {
                currentChargeTime = chargeTime;
                isCharging = false;
                this.gameObject.rigidbody.velocity = moveDir * velocity * Time.deltaTime;
            }
            else
            {
                this.gameObject.rigidbody.velocity = moveDir * chargeVelocity * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currentChargeCooldown = chargeCooldown;

                isCharging = true;
                this.gameObject.rigidbody.velocity = moveDir * chargeVelocity * Time.deltaTime;
            }
            else
            {
                this.gameObject.rigidbody.velocity = moveDir * velocity * Time.deltaTime;

            }
        }

        
	}

    void OnTriggerEnter(Collider col)
    {
        string tag = col.collider.tag;
        if (tag == "Chocolate")
        {
            hasChocolate = true;
            Destroy(col.gameObject);
        }
        else if (tag == "Senpai" && hasChocolate)
        {
            hasChocolate = false;
            score++;
            Debug.Log(this.name + " has been noticed!");
        }
    }
}
