using UnityEngine;
using System.Collections;

public class fabo_memo : MonoBehaviour {
    public GameObject memoObj;

	//	colは触れているコライダーが入る
	//	OnTriggerEnterはコライダーに触れた瞬間に呼ばれる
    void OnTriggerEnter(Collider col)
    {
        //	col(触れているコライダーのタグが"PlayerRange"かつフラグが立っていれば)
        if (col.gameObject.tag == "PlayerRange")
        {
            memoObj.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
