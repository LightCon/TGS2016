using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

	public SerialHandler serialHandler;


    public FlagManager flagManeger;
    [SerializeField]
    private FadeTest _fadeManager;
    //public GameObject player;

    public GameObject gCamera;

    public GameObject images;
    public GameObject FPScontroller;
    public GameObject LightControll;
    public GameObject End;
    public GameObject iconUI;
    public GameObject batteryUI;

	[SerializeField]
	private string _sceneNameBack = "BackTitle";

	[SerializeField]
	private float _invokeTimeBack = 10.0f;


    void OnTriggerEnter(Collider other)
    {
        FPScontroller.GetComponent<FirstPersonController>().enabled = false;
        LightControll.GetComponent<LightButton>().enabled = false;
        if (other.gameObject.tag == "PlayerRange")
        {
            StartCoroutine(MoveCube());
        }
    }

    void Update()
    {

    }

    IEnumerator MoveCube()
    {

        _fadeManager.FadeIn();
        yield return new WaitForSeconds(_fadeManager.FadeTime + 3f);
        //player.SetActive(false);
        iconUI.SetActive(false);
        batteryUI.SetActive(false);

        gCamera.SetActive(true);
        images.SetActive(true);
        End.SetActive(true);
        _fadeManager.FadeOut();
		Invoke(_sceneNameBack, _invokeTimeBack);
        yield return new WaitForSeconds(_fadeManager.FadeTime);

    }

	void BackTitle()
	{
		serialHandler.Close();
		SceneManager.LoadScene("Start");
	}

    internal static void gameObj(bool p)
    {
        throw new System.NotImplementedException();
    }
}