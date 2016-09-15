using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Warp : MonoBehaviour {
    public FlagManager flagManeger;
	[SerializeField]
	private FadeTest _fadeManager;
	public GameObject player;
	public GameObject warpPoint;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PlayerRange")
		{
            if (flagManeger.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_04))
            {
                StartCoroutine(MoveCube());
            }
		}
	}

	void Update()
	{
		
	}

	IEnumerator MoveCube()
	{
		player.GetComponent<FirstPersonController>().enabled = false;
		_fadeManager.FadeIn();
		yield return new WaitForSeconds(_fadeManager.FadeTime + 3f);
		player.transform.localPosition = warpPoint.transform.position;

		_fadeManager.FadeOut();
		yield return new WaitForSeconds(_fadeManager.FadeTime);
		player.GetComponent<FirstPersonController>().enabled = true;


	}


    internal static void gameObj(bool p)
    {
        throw new System.NotImplementedException();
    }
}
