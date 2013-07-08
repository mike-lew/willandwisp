using UnityEngine;
using System.Collections;

public class OrthoScript : MonoBehaviour {
	public GameObject player_;
	private Vector3 offset_;

	// Use this for initialization
	void Start () {
		offset_ = new Vector3(10, 10, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPos = player_.transform.position + offset_;
		transform.position = newPos;
	}
}
