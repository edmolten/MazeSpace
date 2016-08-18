using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {


	const float NORMAL_SPEED = 0.2f;
	const float TURBO_SPEED = 0.3f;
	const float NORMAL_ROTATION_SPEED = 6f;
	const float TURBO_ROTATION_SPEED = 7f;

	public float forwardSpeed;
	public float rotationSpeed;
	public Transform camera;
	public Mode viewMode = Mode.BOTTOM;

	void Start () {
		camera = GameObject.Find ("GameCamera").transform;
		forwardSpeed = NORMAL_SPEED;
		rotationSpeed = NORMAL_ROTATION_SPEED;
	}

	void Update () {
		//camera.RotateAround (transform.position, Vector3.right, 1);
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
		Vector3 upRotation = new Vector3 (0, 0, 90);
		Vector3 downRotation = new Vector3 (0, 0, -90);
		if (Input.GetKeyDown (KeyCode.LeftShift)) { //arriba
			alignFront();
			transform.Rotate (upRotation);
		}
		else if (Input.GetKeyDown (KeyCode.LeftControl)){ //abajo
			alignFront();
			transform.Rotate (downRotation);
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
