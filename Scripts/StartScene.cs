using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

	public SerialHandler serialHandler;

    public GameObject lightObj;

    public SerialIO serialIO;

    private bool startFlag = false;

	[SerializeField]
	private string _sceneName = "LoadSceneMain";

	[SerializeField]
	private float _invokeTime = 2.0f;

	// Use this for initialization
	void Start () {
		lightObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (serialIO.buttonNum == 1 && startFlag == false )
        {
            startFlag = true;
            lightObj.SetActive(true);
            Invoke(_sceneName, _invokeTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("114514");
            startFlag = true;
            lightObj.SetActive(true);
            Invoke(_sceneName, _invokeTime);
        }
	}

    void LoadSceneMain()
    {
		//Debug.Log("ん？今何でもするって？");
		serialHandler.Close();
        SceneManager.LoadScene("AnimationTest");
    }

}
