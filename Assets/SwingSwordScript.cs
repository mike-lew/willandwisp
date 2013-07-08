using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class SwingSwordScript : MonoBehaviour {
	public GameObject arm_;
	
	private bool ready_;

	// Use this for initialization
	void Start () {
		ready_ = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ready_ && Input.GetMouseButton(0)) {
			Sequence seq = new Sequence();
			seq.Append(HOTween.To(arm_.transform, .15f, new TweenParms().Prop("localRotation", new Vector3(100, -15, 0)).Ease(EaseType.Linear)));
			seq.Append(HOTween.To(arm_.transform, .25f, new TweenParms().Prop("localRotation", new Vector3(30, -15, 0)).Ease(EaseType.Linear)));
			seq.AppendCallback(readyUp);
			seq.Play();
			ready_ = false;
		}
	}
	
	private void readyUp() {
		ready_ = true;
	}
}
