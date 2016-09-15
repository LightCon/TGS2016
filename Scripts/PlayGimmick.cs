using UnityEngine;
using System.Collections;

public class PlayGimmick : MonoBehaviour {

	//	操作するanimatorを取得
	public Animator anim;

	//	ドアの種類（一階スライドドアとか）
	public GIMMICK_FLAG _gimmickType;

	//	フラグマネージャーの保持
	public FlagManager flagManager;

    //	colは触れているコライダーが入る
    //	OnTriggerEnterはコライダーに触れた瞬間に呼ばれる
    void OnTriggerEnter(Collider col)
    {
        //	col(触れているコライダーのタグが"PlayerRange"かつフラグが立っていれば)
        if (col.gameObject.tag == "PlayerRange")
        {
            switch (_gimmickType)
            {
                case GIMMICK_FLAG.IS_FOUND_YARN:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)DOOR_FLAG.SLIDE_DOOR))
                    {
                        //anim.SetTrigger("Ban");
                        Debug.Log("test");
                    }
                    break;

                case GIMMICK_FLAG.IS_FOUND_LUMINOUS_TAPE:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_LUMINOUS_TAPE))
                    {

                    }
                    break;

                case GIMMICK_FLAG.IS_UP_STAIRS:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_UP_STAIRS))
                    {

                    }
                    break;

                case GIMMICK_FLAG.IS_OPENEDJACK_IN_THE_BOX:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_OPENEDJACK_IN_THE_BOX))
                    {
                        anim.SetTrigger("Ban");
                        Debug.Log("pppppppp");
                    }
                    break;

                case GIMMICK_FLAG.IS_FOUND_NUMBER:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_NUMBER))
                    {
                        
                    }
                    break;

                case GIMMICK_FLAG.IS_FOUND_ARROW_01:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_ARROW_01))
                    {

                    }
                    break;

                case GIMMICK_FLAG.IS_FOUND_ARROW_02:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_ARROW_02))
                    {

                    }
                    break;
            }
        }
    }

    //	OnTriggerExitはコライダーから離れた瞬間に呼ばれる
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PlayerRange")
        {
            switch (_gimmickType)
            {
                case GIMMICK_FLAG.IS_FOUND_YARN:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_YARN))
                    {

                    }
                    break;
                case GIMMICK_FLAG.IS_FOUND_LUMINOUS_TAPE:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_LUMINOUS_TAPE))
                    {

                    }
                    break;

                case GIMMICK_FLAG.IS_UP_STAIRS:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_UP_STAIRS))
                    {

                    }
                    break;

                case GIMMICK_FLAG.IS_OPENEDJACK_IN_THE_BOX:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_OPENEDJACK_IN_THE_BOX))
                    {

                    }
                    break;

                case GIMMICK_FLAG.IS_FOUND_NUMBER:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_NUMBER))
                    {
                        
                    }
                    break;
                case GIMMICK_FLAG.IS_FOUND_ARROW_01:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_ARROW_01))
                    {
                        
                    }
                    break;
                case GIMMICK_FLAG.IS_FOUND_ARROW_02:
                    if (flagManager.getFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_ARROW_02))
                    {
                        
                    }
                    break;
            }
        }
    }




}
