using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float velocity;
    private float toastVelocity;
    private float chargeVelocity;
    private float toastTime;
    private float chargeTime;
    private float currentChargeTime;
    private float chargeCooldown;

    private bool hasChocolate;
    private int noChocolatesHeld;

    private float maxSpeed;
    private Vector3 moveDir;

    private bool isCharging;
    private bool hasToast;
    private bool isGhosting;
    private float spookyTime;

    private float currentChargeCooldown;

    private int score;
    private int scoreMultiplier;

    private Animator animator;
    private string player = "player0";

	// Use this for initialization
	void Start () {
        velocity = 500.0f;
        toastVelocity = 750.0f;
        chargeVelocity = 2000.0f;
        chargeTime = 0.25f;
        currentChargeTime = chargeTime;
        chargeCooldown = 5.0f;
        currentChargeCooldown = 5.0f;
        maxSpeed = 50.0f;
        score = 0;
        toastTime = 5.0f; //seconds
        scoreMultiplier = 1;
        hasChocolate = false;
        noChocolatesHeld = 0;
        isCharging = false;
        hasToast = false;
        isGhosting = false;
        spookyTime = 10.0f;
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(currentChargeTime);
        currentChargeCooldown -= Time.deltaTime;
        if (isGhosting)
        {
            spookyTime -= Time.deltaTime;
            if (spookyTime <= 0)
            {
                isGhosting = false;
                spookyTime = 10.0f;
                foreach (GameObject desk in GameObject.FindGameObjectsWithTag("Desk"))
                {
                    Physics.IgnoreCollision(this.collider, desk.collider, false);
                }
            }
        }
        if (!isCharging)
        {
            moveDir = Vector3.zero;
        }


        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        { 
            animator.Play("Idle");
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.Play("Walk Up");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("Walk Down");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("Walk Left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.Play("Walk Right");
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

        if (hasToast)
        {
            Debug.Log("HAS TOAST");
            toastTime -= Time.deltaTime;
            if (toastTime <= 0.0f)
            {
                Debug.Log("NO TOAST");
                hasToast = false;
                toastTime = 5.0f;
            }

            this.gameObject.rigidbody.velocity = moveDir * toastVelocity * Time.deltaTime;
        }

        else if (isCharging)
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
            noChocolatesHeld++;
            Debug.Log("has " + noChocolatesHeld);
            scoreMultiplier++;
            Destroy(col.gameObject);
        }
        else if (tag == "Senpai" && hasChocolate)
        {
            hasChocolate = false;
            score += noChocolatesHeld * scoreMultiplier;
            Debug.Log("score: " + score);
            noChocolatesHeld = 0;
            scoreMultiplier = 1;
            Debug.Log(this.name + " has been noticed!");
        }
        else if (tag == "Toast")
        {
            hasToast = true;
            Destroy(col.gameObject);
        }
        else if (tag == "Ghost")
        {
            isGhosting = true;
            Destroy(col.gameObject);
            foreach(GameObject desk in GameObject.FindGameObjectsWithTag("Desk")) {
                Physics.IgnoreCollision(this.collider, desk.collider, true);
            }
        }
    }
}
