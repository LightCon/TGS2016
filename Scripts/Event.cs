using UnityEngine;
using System.Collections;

/// <summary>
/// イベント
/// </summary>
public class Event : MonoBehaviour {

	/// <summary>
	/// フラグマネージャーの保持
	/// </summary>
	public FlagManager flagManager;

	/// <summary>
	/// ギミックの種類
	/// </summary>
	public GIMMICK_FLAG gimmick_flag;


	void OnTriggerEnter(Collider col)
	{
		// TODO:GIMMICK_FLAGと対応させる
		//	プレイヤーと接触した場合
		if (col.gameObject.tag == "PlayerRange")
		{
			switch (gimmick_flag)
			{
				case GIMMICK_FLAG.IS_FOUND_YARN:
					// ２番目のメモを入手していたなら
					if (flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_02))
					{
						flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.SLIDE_DOOR, false);
						flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.LIVING_DOOR, true);
						//Destroy(gameObject);
                        
					}                    
					break;
                case GIMMICK_FLAG.IS_ROOM_CLOSE:
                    // 閉じ込められたら
                    if (flagManager.getFlag(FLAG.DOOR, (int)DOOR_FLAG.SLIDE_DOOR)) 
                    {
                    
                    }
                    else
                    {
                        flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.SLIDE_DOOR, true);
                    }
                    break;
				default:break;
			}
		}
	}
}
