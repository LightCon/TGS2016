using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum firstDoorAnimID
{
	NULL = -1,
	DOOR = 0,
	SLIDING_DOOR
}


public class DoorControl : MonoBehaviour {

	//	一階のアニメーター
	public Animator firstAnimator;

	List<string> doorAnimName = new List<string>
	{
		"doorOpen",
		"slidingDoorOpen"
	};

	public void setFirstDoorAnimation(firstDoorAnimID animID, bool isOpen)
	{
		firstAnimator.SetBool(getAnimationName(animID), isOpen);
	}

	public string getAnimationName(firstDoorAnimID animID)
	{
		return doorAnimName[(int)animID];
	}
}
