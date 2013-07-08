using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class WalkScript : MonoBehaviour {
	public Camera cam_;
	public GameObject leftHip_;
	public GameObject rightHip_;
	
	private bool isWalking_;
	private Sequence seql_;
	private Sequence seqr_;
	
	// Use this for initialization
	void Start () {
		isWalking_ = false;
		seql_ = new Sequence();
		seqr_ = new Sequence();
	}
	
	void FixedUpdate () {
		if (!isWalking_ && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)) {
			isWalking_ = true;
			seql_.Clear();
			seqr_.Clear();
			seql_ = new Sequence(new SequenceParms().Loops(-1, LoopType.Restart));
			seql_.Append(HOTween.To(leftHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(15, 0, 0)).Ease(EaseType.Linear)));
			seql_.Append(HOTween.To(leftHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(-15, 0, 0)).Ease(EaseType.Linear)));
			seqr_ = new Sequence(new SequenceParms().Loops(-1, LoopType.Restart));
			seqr_.Append(HOTween.To(rightHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(-15, 0, 0)).Ease(EaseType.Linear)));
			seqr_.Append(HOTween.To(rightHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(15, 0, 0)).Ease(EaseType.Linear)));
			seql_.Play();
			seqr_.Play();
		}
		
		if (isWalking_ && (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)) {
			isWalking_ = false;
			seql_.Clear();
			seqr_.Clear();
			seql_ = new Sequence();
			seql_.Append(HOTween.To(leftHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
			seqr_ = new Sequence();
			seqr_.Append(HOTween.To(rightHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
			seql_.Play();
			seqr_.Play();
		}
	}
	
	void OnDestroy() {
		seql_.Clear();
		seqr_.Clear();
	}
	
}
