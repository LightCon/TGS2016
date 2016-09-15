using UnityEngine;
using System.Collections;


public class OpenDoor : MonoBehaviour {

    public GameObject toys;

	//	操作するanimatorを取得
	public Animator anim;
    public Animator anim2;

	//	ドアの種類（一階スライドドアとか）
	public DOOR_FLAG _doorType;

	//	フラグマネージャーの保持
	public FlagManager flagManager;

	//	colは触れているコライダーが入る
	//	OnTriggerEnterはコライダーに触れた瞬間に呼ばれる
	void OnTriggerEnter(Collider col)
	{
		//	col(触れているコライダーのタグが"PlayerRange"かつフラグが立っていれば)
		if (col.gameObject.tag == "PlayerRange")
		{
			switch (_doorType)
			{
				case DOOR_FLAG.SLIDE_DOOR:
					if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.SLIDE_DOOR))
					{
						//	メカニムで設定したトリガー発動
                        anim.SetTrigger("sDoorOpen");
					}
					break;

				case DOOR_FLAG.LIVING_DOOR:
					if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.LIVING_DOOR))
					{
                        anim.SetTrigger("doorOpen");
					}
					break;

				//	判定を増やす場合
				//	DOOR_FLAGにすべてのドアが入っているから、そのままcaseを増やす
				//	以下追加
				case DOOR_FLAG.FIRST_FLOOR_STAIRS:
					//	↓に処理を追加

					break;

				case DOOR_FLAG.SECOND_FLOOR_STAIRS:

					break;

				case DOOR_FLAG.MY_ROOM_DOOR:
                    if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.MY_ROOM_DOOR))
                    {
                        Debug.Log("test");
                        anim.SetTrigger("CDoor_open");
                    }
					break;

				case DOOR_FLAG.BROTHERS_ROOM_DOOR:
                    if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.BROTHERS_ROOM_DOOR))
                    {
                        Debug.Log("test");
                        anim.SetTrigger("BDoor_open");
                    }
					break;

				case DOOR_FLAG.PARENTS_ROOM_DOOR:
                    if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.PARENTS_ROOM_DOOR))
                    {
                        Debug.Log("test");
                        anim.SetTrigger("ADoor_open");
                        toys.SetActive(true);

                    }
					break;
                    
               /* case DOOR_FLAG.MY_ROOM_DOOR;
                     if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.MY_ROOM_DOOR))
                    {
                        Debug.Log("test");
                        anim.SetTrigger("CDoor_open");
                    }
					break;*/

			}
		}
	}

	//	OnTriggerExitはコライダーから離れた瞬間に呼ばれる
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "PlayerRange")
		{
			switch (_doorType)
			{
				case DOOR_FLAG.SLIDE_DOOR:
					if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.SLIDE_DOOR))
					{
						anim.SetTrigger("sDoorClose");
					}
					break;
				case DOOR_FLAG.LIVING_DOOR:
					if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.LIVING_DOOR))
					{
						anim.SetTrigger("doorClose");
					}
					break;


				//	判定を増やす場合
				//	DOOR_FLAGにすべてのドアが入っているから、そのままcaseを増やす
				//	以下追加
				case DOOR_FLAG.FIRST_FLOOR_STAIRS:
					//	↓に処理を追加

					break;

				case DOOR_FLAG.SECOND_FLOOR_STAIRS:

					break;

                case DOOR_FLAG.MY_ROOM_DOOR:
                    if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.MY_ROOM_DOOR))
                    {
                        anim.SetTrigger("CDoor_close");
                    }
                    break;
                case DOOR_FLAG.BROTHERS_ROOM_DOOR:
                    if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.BROTHERS_ROOM_DOOR))
                    {
                        anim.SetTrigger("BDoor_close");
                    }
                    break;
                case DOOR_FLAG.PARENTS_ROOM_DOOR:
                    if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.PARENTS_ROOM_DOOR))
                    {
                        anim.SetTrigger("ADoor_close");
                    }
                    break;
			}
		}
	}
}
