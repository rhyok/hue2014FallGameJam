using UnityEngine;
using System.Collections;

public class Chocolate : MonoBehaviour {

    private bool isBeingHeld;
    private float cooldown;
    private Vector2 location;

    public float RotateSpeed = 0.9f;

	// Use this for initialization
	void Start () {
        isBeingHeld = false;
	}
	
	// Update is called once per frame
	void Update () {
	    this.gameObject.transform.Rotate(Vector3.forward, RotateSpeed);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.collider.tag == "Player")
        {
            isBeingHeld = true;
        }
    }

}
