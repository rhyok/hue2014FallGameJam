using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float velocity;
    private bool hasChocolate;
    private float acceleration;
    private float accelerationMultiplier;
    private float maxSpeed;

	// Use this for initialization
	void Start () {
        velocity = 10.0f;
        maxSpeed = 10.0f;
        acceleration = 0.0f;
        accelerationMultiplier = 0.5f;
        hasChocolate = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(hasChocolate);
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(-Vector3.forward * velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(-Vector3.left * velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(-Vector3.right * velocity * Time.deltaTime);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.collider.tag == "Chocolate")
        {
            hasChocolate = true;
        }
    }
}
