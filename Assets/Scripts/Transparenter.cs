using UnityEngine;
using System.Collections;

public class Transparenter : MonoBehaviour
{
	static private GameObject[] blocks;

	void Start(){
		blocks = GameObject.FindGameObjectsWithTag ("Wall");
		Transparenter.transparentBlocksOnTop (transform);
	}

	public static void transparentBlocksOnTop(Transform playerTransform){
		Color c;
		Vector3 p;
		Material m;
		foreach (GameObject block in blocks) {
			m = block.GetComponent<MeshRenderer> ().material;
			c = m.color;
			p = relativePosition(playerTransform, block.transform.position);
			if (p.x > 1.7f) {
				c.a = 0.2f;
			} else {
				c.a = 1.0f;
			}
			m.color = c;
		}
	}
		
	static private Vector3 relativePosition(Transform origin, Vector3 position) {
		return origin.InverseTransformVector (position);
	}
}