using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class ShieldScript : MonoBehaviour {
	public GameObject arm_;
	
	private bool isBlocking_;
	private Sequence seq_;
	
	// Use this for initialization
	void Start () {
		isBlocking_ = false;
		seq_ = new Sequence();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			float interrupt = seq_.elapsed;
			seq_.Pause();
			seq_.Clear();
			seq_ = new Sequence();
			seq_.Append(HOTween.To(arm_.transform, .25f , new TweenParms().Prop("localRotation", new Vector3(75, 15, 0)).Ease(EaseType.Linear)));
			seq_.AppendCallback(blocking);
			seq_.Play();
		}
		if (Input.GetMouseButtonUp(1)) {
			float interrupt = seq_.elapsed;
			seq_.Pause();
			seq_.Clear();
			seq_ = new Sequence();
			seq_.Append(HOTween.To(arm_.transform, .25f , new TweenParms().Prop("localRotation", new Vector3(75, -45, 0)).Ease(EaseType.Linear)));
			seq_.AppendCallback(unblocking);
			seq_.Play();
		}
	}
	
	private void unblocking() {
		isBlocking_ = false;
	}
	
	private void blocking() {
		isBlocking_ = true;
	}
}
