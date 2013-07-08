using UnityEngine;
using System.Collections;

public class CamSwitchScript : MonoBehaviour {
	public Camera RegCam_;
	public Camera OrthoCam_;
	public Camera DeathCam_;
	
	private bool camSwitch_;
	// Use this for initialization
	void Start () {
		camSwitch_ = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyUp(KeyCode.Tab)) {
			if (!camSwitch_) { //reg to ortho
				camSwitch_ = true;
				RegCam_.camera.enabled = false;
				OrthoCam_.camera.enabled = true;
				OrthoCam_.transform.LookAt(transform);
				gameObject.transform.Find("HitTrigger").GetComponent<DamageScript>().deathCamera_ = OrthoCam_;
			}
			
			else { //ortho to reg
				camSwitch_ = false;
				RegCam_.camera.enabled = true;
				OrthoCam_.camera.enabled = false;
				gameObject.transform.Find("HitTrigger").GetComponent<DamageScript>().deathCamera_ = DeathCam_;
			}
		}
	}
}
