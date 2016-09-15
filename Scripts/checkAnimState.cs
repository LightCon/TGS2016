using UnityEngine;
using System.Collections;

public class checkAnimState : MonoBehaviour {

    AnimatorStateInfo animInfo;
    [SerializeField]
    GameObject memo;
    [SerializeField]
    bool state = false;
    bool active = true;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        animInfo = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
  
        if (animInfo.normalizedTime > 0f && animInfo.normalizedTime <= 0.9f)
        {
           // Debug.Log("お願いします！何でもしますから！");
            state = true;
        }
        else
        {
            //Debug.Log("ん？今何でもするって？");
            if (state)
            {
                memo.SetActive(true);
                this.GetComponent<Animator>().enabled = memo.activeInHierarchy;
            }
        }
        
        
	}
}
