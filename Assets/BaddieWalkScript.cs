using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class BaddieWalkScript : MonoBehaviour {
	public GameObject leftHip_;
	public GameObject rightHip_;
	
	public bool isWalking_;
	private Sequence seql_;
	private Sequence seqr_;
	
	// Use this for initialization
	void Start () {
		isWalking_ = false;
		seql_ = new Sequence(new SequenceParms().Loops(-1, LoopType.Restart));
		seql_.Append(HOTween.To(leftHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(30, 0, 0)).Ease(EaseType.Linear)));
		seql_.Append(HOTween.To(leftHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
		seqr_ = new Sequence(new SequenceParms().Loops(-1, LoopType.Restart));
		seqr_.Append(HOTween.To(rightHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
		seqr_.Append(HOTween.To(rightHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(30, 0, 0)).Ease(EaseType.Linear)));
	}
	
	void FixedUpdate () {
		if (isWalking_) {
			seql_.Play();
			seqr_.Play();
		}
		else {
			seql_.Pause();
			seqr_.Pause();
		}
//		if (!isWalking_) {
//			isWalking_ = false;
//			seql_.Clear();
//			seqr_.Clear();
//			seql_ = new Sequence();
//			seql_.Append(HOTween.To(leftHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
//			seqr_ = new Sequence();
//			seqr_.Append(HOTween.To(rightHip_.transform, .1f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
//			seql_.Play();
//			seqr_.Play();
//		}
	}
	
	void OnDestroy() {
		seql_.Clear();
		seqr_.Clear();
	}
}
