using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	const float NORMAL_SPEED = 0.1f;
	const float TURBO_SPEED = 0.2f;
	const float NORMAL_ROTATION_SPEED = 5f;
	const float TURBO_ROTATION_SPEED = 6f;

	public float forwardSpeed;
	public float rotationSpeed;
	public Mode viewMode = Mode.BOTTOM;
	Vector3 upRotation;
	Vector3 downRotation;

	void Start () {
		forwardSpeed = NORMAL_SPEED;
		rotationSpeed = NORMAL_ROTATION_SPEED;
		upRotation = new Vector3 (0, 0, 90);
		downRotation = new Vector3 (0, 0, -90);
	}

	void Update () {
		checkTurbo ();
		checkPlaneChange ();
		checkRotation ();
		moveForward ();
	}
		
	void checkTurbo(){ 
		if (Input.GetKeyDown (KeyCode.Space)) {
			forwardSpeed = TURBO_SPEED;
			rotationSpeed = TURBO_ROTATION_SPEED;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			forwardSpeed = NORMAL_SPEED ;
			rotationSpeed = NORMAL_ROTATION_SPEED;
		}
	}

	void checkPlaneChange(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			alignFront();
			transform.Rotate (upRotation);
			Transparenter.transparentBlocksOnTop (transform);
		}
		else if (Input.GetKeyDown (KeyCode.LeftControl)){
			alignFront();
			transform.Rotate (downRotation);
			Transparenter.transparentBlocksOnTop (transform);
		}
	}

	void alignFront(){
		Vector3 vec = transform.eulerAngles;
		vec.x = Mathf.Round(vec.x / 90) * 90;
		vec.y = Mathf.Round(vec.y / 90) * 90;
		vec.z = Mathf.Round(vec.z / 90) * 90;
		transform.eulerAngles = vec;
	}

	void checkRotation (){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (rotationSpeed, 0, 0));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (-rotationSpeed, 0, 0));
		}
	}

	void moveForward(){
		transform.Translate (new Vector3 (0, forwardSpeed, 0));
	}

}
