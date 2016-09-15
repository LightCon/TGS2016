using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// メモフラグ
/// </summary>
[SerializeField]
public enum MEMO_FLAG
{
	NULL = -1,
	MEMO_01,
	MEMO_02,
	MEMO_03,
	MEMO_04,
	MEMO_05,
	MEMO_06,
	MEMO_07,
	MEMO_08,
	MEMO_09,
	MEMO_10,
	NUM
}

/// <summary>
///		アイテムフラグ
/// </summary>
[SerializeField]
public enum ITEM_FLAG
{
	NULL = -1,
	LIGHT,
	KEY,
	MEMO,
	NUM
}

/// <summary>
/// ギミックフラグ
/// </summary>
[SerializeField]
public enum GIMMICK_FLAG
{
	NULL = -1,
	IS_FOUND_YARN,
    IS_ROOM_CLOSE,
	IS_FOUND_LUMINOUS_TAPE,
	IS_UP_STAIRS,
	IS_OPENEDJACK_IN_THE_BOX,
	IS_FOUND_NUMBER,
	IS_FOUND_ARROW_01,
	IS_FOUND_ARROW_02,
	NUM
}


/// <summary>
///	ドアの開放フラグ
/// </summary>
[SerializeField]
public enum DOOR_FLAG
{
	NULL = -1,
	SLIDE_DOOR,
	LIVING_DOOR,
	FIRST_FLOOR_STAIRS,
	SECOND_FLOOR_STAIRS,
	MY_ROOM_DOOR,
	BROTHERS_ROOM_DOOR,
	PARENTS_ROOM_DOOR,
	NUM
}

/// <summary>
/// フラグの種類
/// </summary>
public enum FLAG
{
	NULL = -1,
	MEMO,
	ITEM,
	GIMMICK,
	DOOR,
	NUM
}

/// <summary>
/// フラグ管理クラス
/// フラグのセットや設定を行う
/// </summary>
public class FlagManager : MonoBehaviour
{
	/// <summary>
	/// フラグリスト
	/// </summary>
	public List<bool[]> List_flag;

	/// <summary>
	/// インスペクターで表示して確認する用
	/// </summary>
	[SerializeField]
	private bool[] List_memoFlag;

	/// <summary>
	/// インスペクターで表示して確認する用
	/// </summary>
	[SerializeField]
	private bool[] List_itemFlag;

	/// <summary>
	/// インスペクターで表示して確認する用
	/// </summary>
	[SerializeField]
	private bool[] List_gimmickFlag;

	/// <summary>
	/// インスペクターで表示して確認する用
	/// </summary>
	[SerializeField]
	private bool[] List_doorFlag;

	void Start()
	{
		//	要素の数を設定
		List_flag = new List<bool[]>
		{
			new bool[(int)MEMO_FLAG.NUM],
			new bool[(int)ITEM_FLAG.NUM],
			new bool[(int)GIMMICK_FLAG.NUM],
			new bool[(int)DOOR_FLAG.NUM]
		};

		check();
	}

	/// <summary>
	/// フラグをセット
	/// </summary>
	/// <param name="_flagType">フラグタイプ</param>
	/// <param name="_typeID">フラグの場所</param>
	/// <param name="_flag">セット</param>
	public void setFlag(FLAG _flagType, int _typeID, bool _flag)
	{
		List_flag[(int)_flagType][_typeID] = _flag;
		check();
	}

	/// <summary>
	/// フラグの情報を入手
	/// </summary>
	/// <param name="_flagType">フラグタイプ</param>
	/// <param name="_typeID">フラグの場所</param>
	/// <returns>フラグの状態</returns>
	public bool getFlag(FLAG _flagType, int _typeID)
	{
		return List_flag[(int)_flagType][_typeID];
	}

	/// <summary>
	/// フラグの可視化用
	/// </summary>
	void check() {
		List_memoFlag = List_flag[(int)FLAG.MEMO];
		List_itemFlag = List_flag[(int)FLAG.ITEM];
		List_gimmickFlag = List_flag[(int)FLAG.GIMMICK];
		List_doorFlag = List_flag[(int)FLAG.DOOR];
	}

    internal void setFlag(FLAG fLAG, int p)
    {
        //throw new System.NotImplementedException();
    }
}
