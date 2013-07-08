using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {
	public Transform parent_;
	public Camera mainCamera_;
	public Camera deathCamera_;
	
	void Start() {
	}
	
	void FixedUpdate() {
	}
	
	void OnTriggerEnter(Collider c) {
		Debug.Log(c.name);
		if (c.gameObject.tag == "Weapon") {
			Explode();
			Debug.Log(parent_.tag + " explodes!");
		}
	}
	
	private void Explode() {
		if (mainCamera_) mainCamera_.enabled = false;
		if (deathCamera_) deathCamera_.enabled = true;
		foreach (Transform part in parent_.GetComponentsInChildren<Transform>()) {
			foreach (MonoBehaviour script in part.gameObject.GetComponents<MonoBehaviour>()) {
				Destroy(script);
			}
			string tag = part.gameObject.tag;
			if (tag == "BodyPart" || tag == "Weapon" || tag == "Shield") {
				GameObject p = part.gameObject;
				p.AddComponent<Rigidbody>();
				p.tag = "BodyPart";
			}
		}
		Destroy(parent_.rigidbody);
	}
}
