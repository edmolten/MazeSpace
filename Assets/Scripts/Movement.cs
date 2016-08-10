using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float forwardSpeed = 0.1f;
	public float rotationSpeed = 3.5f;

	void Start () {

	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			forwardSpeed = 0.2f;
			rotationSpeed = 4.0f;
		}
		else if (Input.GetKeyUp(KeyCode.Space)){
			forwardSpeed = 0.1f;
			rotationSpeed = 3.5f;
		}
		transform.Translate (new Vector3 (0, forwardSpeed , 0));
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (rotationSpeed, 0, 0));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (-rotationSpeed, 0, 0));
		}
	}
}
