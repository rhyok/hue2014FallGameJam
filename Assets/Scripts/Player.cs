using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float velocity;
    private bool hasChocolate;
    private float acceleration;
    private float accelerationMultiplier;
    private float maxSpeed;
    private Vector3 moveDir;

	// Use this for initialization
	void Start () {
        velocity = 500.0f;
        maxSpeed = 50.0f;
        acceleration = 0.0f;
        accelerationMultiplier = 0.5f;
        hasChocolate = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(hasChocolate);

        moveDir = Vector3.zero;

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

        this.gameObject.rigidbody.velocity = moveDir * velocity * Time.deltaTime;
	}

    void OnTriggerEnter(Collider col)
    {
        string name = col.collider.name;
        if (name == "Chocolate")
        {
            hasChocolate = true;
            Destroy(col.gameObject);
        }
        else if (name == "Senpai")
        {
            hasChocolate = false;
        }
    }
}
