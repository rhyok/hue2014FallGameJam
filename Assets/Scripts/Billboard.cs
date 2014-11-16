using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	void Update () {
        Vector3 oppositeCamera = transform.position - Camera.main.transform.position;
        Quaternion faceCamera = Quaternion.LookRotation(oppositeCamera);
        Vector3 euler = faceCamera.eulerAngles;
        euler.y = 0f;
        faceCamera.eulerAngles = euler;
        transform.rotation = faceCamera;
	}
}
