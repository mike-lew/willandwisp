using UnityEngine;
using System.Collections;

public class ResetLevelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width - 95, Screen.height - 55, 90, 50), "Reset Level")){
			Application.LoadLevel ("willFight");
		}
	}
}
