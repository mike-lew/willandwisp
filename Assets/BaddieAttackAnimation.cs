using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class BaddieAttackAnimation : MonoBehaviour {
	public GameObject target_;
	public Transform torsoJoint_;
	public Transform leftShoulder_;
	public Transform rightShoulder_;
	
	private float range_ = 4;
	
	private bool isAnimatingT_;
	private bool isAnimatingL_;
	private bool isAnimatingR_;
	private Sequence seqt_;
	private Sequence seqr_;
	private Sequence seql_;

	// Use this for initialization
	void Start () {
		isAnimatingT_ = false;
		isAnimatingR_ = false;
		isAnimatingL_ = false;
		seqt_ = new Sequence();
		seqr_ = new Sequence();
		seql_ = new Sequence();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isAnimatingT_ && !isAnimatingR_ && !isAnimatingL_ && InRange()) {
			int ani = Random.Range(0, 3);
			switch (ani) {
			case 0:
				DoubleSwipe();
				break;
			case 1:
				RightSwipe();
				break;
			case 2:
				LeftSwipe();
				break;
			}
		}
	}
	
	private bool InRange() {
		if ((target_.transform.position - transform.position).magnitude < range_) return true;
		return false;
	}
	
	private void DoubleSwipe() {
		Debug.Log("double swipe!");
		isAnimatingT_ = true;
		isAnimatingR_ = true;
		isAnimatingL_ = true;
		seqt_ = new Sequence();
		seqt_.Append(HOTween.To(torsoJoint_, .5f , new TweenParms().Prop("localRotation", new Vector3(-30, 0, 0)).Ease(EaseType.Linear)));
		seqt_.Append(HOTween.To(torsoJoint_, .5f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
		seqt_.AppendCallback(freeAnimationT);
		seqr_ = new Sequence();
		seqr_.Append(HOTween.To(rightShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seqr_.Append(HOTween.To(rightShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, -45)).Ease(EaseType.Linear)));
		seqr_.Append(HOTween.To(rightShoulder_, .5f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seqr_.AppendCallback(freeAnimationR);
		seql_ = new Sequence();
		seql_.Append(HOTween.To(leftShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seql_.Append(HOTween.To(leftShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 45)).Ease(EaseType.Linear)));
		seql_.Append(HOTween.To(leftShoulder_, .5f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seql_.AppendCallback(freeAnimationL);
		seqt_.Play();
		seqr_.Play();
		seql_.Play();
	}
	
	private void RightSwipe() {
		Debug.Log("right swipe!");
		isAnimatingT_ = true;
		isAnimatingR_ = true;
		isAnimatingL_ = true;
		seqt_ = new Sequence();
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(-30, 0, 0)).Ease(EaseType.Linear)));
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(-30, -30, 0)).Ease(EaseType.Linear)));
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(-30, 0, 0)).Ease(EaseType.Linear)));
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
		seqt_.AppendCallback(freeAnimationT);
		seqr_ = new Sequence();
		seqr_.Append(HOTween.To(rightShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seqr_.Append(HOTween.To(rightShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, -45)).Ease(EaseType.Linear)));
		seqr_.Append(HOTween.To(rightShoulder_, .5f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seqr_.AppendCallback(freeAnimationR);
		seql_ = new Sequence();
		seql_.Append(HOTween.To(leftShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seql_.Append(HOTween.To(leftShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, -45)).Ease(EaseType.Linear)));
		seql_.Append(HOTween.To(leftShoulder_, .5f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seql_.AppendCallback(freeAnimationL);
		seqt_.Play();
		seqr_.Play();
		seql_.Play();
	}
	
	private void LeftSwipe() {
		Debug.Log("left swipe!");
		isAnimatingT_ = true;
		isAnimatingR_ = true;
		isAnimatingL_ = true;
		seqt_ = new Sequence();
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(-30, 0, 0)).Ease(EaseType.Linear)));
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(-30, 30, 0)).Ease(EaseType.Linear)));
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(-30, 0, 0)).Ease(EaseType.Linear)));
		seqt_.Append(HOTween.To(torsoJoint_, .25f , new TweenParms().Prop("localRotation", new Vector3(0, 0, 0)).Ease(EaseType.Linear)));
		seqt_.AppendCallback(freeAnimationT);
		seqr_ = new Sequence();
		seqr_.Append(HOTween.To(rightShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seqr_.Append(HOTween.To(rightShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 45)).Ease(EaseType.Linear)));
		seqr_.Append(HOTween.To(rightShoulder_, .5f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seqr_.AppendCallback(freeAnimationR);
		seql_ = new Sequence();
		seql_.Append(HOTween.To(leftShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seql_.Append(HOTween.To(leftShoulder_, .25f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 45)).Ease(EaseType.Linear)));
		seql_.Append(HOTween.To(leftShoulder_, .5f , new TweenParms().Prop("localRotation", new Vector3(315, 0, 0)).Ease(EaseType.Linear)));
		seql_.AppendCallback(freeAnimationL);
		seqt_.Play();
		seqr_.Play();
		seql_.Play();
	}
	
	private void freeAnimationT() {
		isAnimatingT_ = false;
	}
	
	private void freeAnimationR() {
		isAnimatingR_ = false;
	}
	
	private void freeAnimationL() {
		isAnimatingL_ = false;
	}
	
	void OnDestroy() {
		seqt_.Clear();
		seqr_.Clear();
		seql_.Clear();
	}
}
