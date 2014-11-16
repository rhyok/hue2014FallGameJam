using UnityEngine;
using System.Collections;

public class PlayerRenderer : MonoBehaviour {
    private Animator animator;

	// Use this for initialization
	void Start () {
	    animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
