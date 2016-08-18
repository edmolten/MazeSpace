using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public Transform player;
	public float distance;
	public Vector3 moveVector;
	public Transform playerTransform;
	public Mode playerMode;

	void Start () {
		GameObject player = GameObject.Find ("Spaceship");
		ShipMovement shipMovement = player.GetComponent<ShipMovement> ();
		playerTransform = player.transform;
		playerMode = shipMovement.viewMode;
		distance = 40;
	}

	void Update(){
		//Vector3 playerPosition = playerTransform.position;
		//if(playerMode.Equals(Mode.BOTTOM)){
		//	transform.position = new Vector3 (playerPosition.x, playerPosition.y + distance, playerPosition.z);
		//}
		//else if
		//

	}
}
