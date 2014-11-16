using UnityEngine;
using System.Collections;

public class Toast : Powerup {
    
	// Use this for initialization
	void Start () {
        powerup = Resources.Load("Objects/Toast") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
