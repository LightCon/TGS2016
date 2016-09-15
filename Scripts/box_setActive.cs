using UnityEngine;
using System.Collections;

public class box_setActive : MonoBehaviour {

    public GameObject box;
    public FlagManager flagmanegger;
    public GIMMICK_FLAG gimmickType;

	//	colは触れているコライダーが入る
	//	OnTriggerEnterはコライダーに触れた瞬間に呼ばれる
    void OnTriggerEnter(Collider col)
    {
        //	col(触れているコライダーのタグが"PlayerRange"かつフラグが立っていれば)
        if (col.gameObject.tag == "PlayerRange")
        {
            box.SetActive(true);
            Destroy(gameObject);
        }
    }



	
	// Update is called once per frame
	void Update () {
	
	}
}
