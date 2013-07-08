using UnityEngine;
using System.Collections;

public class ActivateBaddieScript : MonoBehaviour {
	public GameObject player_;
	public GameObject baddie_;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider c) {
		if (baddie_.GetComponent<BaddieChaseScript>() != null)
			baddie_.GetComponent<BaddieChaseScript>().target_ = player_;
	}
}
