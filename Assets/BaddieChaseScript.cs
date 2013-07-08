using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class BaddieChaseScript : MonoBehaviour {
	public GameObject target_;
	
	public float maxTurnSpeed_ = 1;
	public float minFacingAngle_ = 20;
	public float minChaseDistance_ = 4;
	public float maxChaseAngle_ = 45;
	public float chaseSpeed_ = 5;
	// Use this for initialization
	void Start () {
		//target_ = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target_ != null) {
			Vector3 relativePos = target_.transform.position - transform.position;
			relativePos.y = .75f;
			float angle = Vector3.Angle(transform.forward, relativePos);
			bool walk = false;
			if (angle > minFacingAngle_) {
				walk = true;
				if (Vector3.Cross(transform.forward, relativePos).y < 0) {
					transform.RotateAround(transform.up, maxTurnSpeed_ * Time.fixedDeltaTime * -1);
				}
				else {
					transform.RotateAround(transform.up, maxTurnSpeed_ * Time.fixedDeltaTime);
				}
			}
			if (relativePos.magnitude > minChaseDistance_ && angle < maxChaseAngle_) {
				walk = true;
				rigidbody.velocity = relativePos.normalized * chaseSpeed_;
			}
			if (walk == true) gameObject.GetComponent<BaddieWalkScript>().isWalking_ = true;
			else gameObject.GetComponent<BaddieWalkScript>().isWalking_ = false;
		}
	}
}
