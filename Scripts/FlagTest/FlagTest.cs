using UnityEngine;
using System.Collections;

public class FlagTest : MonoBehaviour {

	/// <summary>
	/// フラグマネージャーを指定(GameRoot)
	/// </summary>
	[SerializeField]	//	←これはプライベートだけどインスペクターで表示させるため
	private FlagManager _flagManager;

	void Start () 
	{
		//	フラグの状態を確認する
		Debug.Log(_flagManager.getFlag(FLAG.MEMO, 10));

		hoge();
	}
	
	void hoge()
	{
		//	フラグセット時
		//	例えばメモの10番目を入手したことにする
		_flagManager.setFlag(FLAG.MEMO, 10, true);

		//	フラグの状態を確認する
		Debug.Log(_flagManager.getFlag(FLAG.MEMO, 10));
	}
}
