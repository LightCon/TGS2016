using UnityEngine;
using System.Collections;

public enum doorType
{
	DOOR,
	SLIDING
}

public class DoorTest : MonoBehaviour {

	public doorType doorType;
	public DoorControl doorControl;
	bool doorFlag = false;

	public void doorBtn()
	{
		doorFlag = !doorFlag;
		doorControl.setFirstDoorAnimation((firstDoorAnimID)doorType, doorFlag);
	}
}
