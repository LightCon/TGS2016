using UnityEngine;
using System.Collections;

public class IsInCamera : MonoBehaviour {

	//	ライトに付けているカメラのタグ名
	private const string LIGHT_CONTROLLER_CAMERA_TAG_NAME = "LightControllerCamera";
	public LightButton _lightButton;

	public LightMode _lightMode;

	//	カメラに表示されているか
	public bool _isRendered = false;
	//629
	//private Renderer _reRenderer = null;

	private Renderer _myRenderer = null;
	private Color _myColor;

	public bool _colorFlag = false;

	void Start () {
		_myRenderer = this.GetComponent<Renderer>();
		//初めの色を_myColorに格納
		_myColor = _myRenderer.material.color;

	}
	
	void Update () {
		//カメラに映っているかの判定
		if(_isRendered)
		{
			Debug.Log("カメラに写っている");
			//今のマテリアルのカラーの透明度が０以上(つまり透明でなければ)
			if(_myRenderer.material.color.a > 0)
			{
				//ブラックライト
				if (_lightButton._lightMode == LightMode.BLACK) 
				{
					//_myRenderer.material.color += new Color (-Time.deltaTime, Time.deltaTime, -Time.deltaTime, 0);
					_myRenderer.material.EnableKeyword ("_EMISSION");
					//_myRenderer.material.SetColor ("_EmissionColor", new Color (0, 1, 0));
					_colorFlag = true;
					//コルーチンに飛ぶ
					StartCoroutine(ColorChange());

				//ブラックライト以外
				} 
				if (_lightButton._lightMode != LightMode.BLACK) 
				{
					_colorFlag = false;
				}
				if (_lightButton._lightMode == LightMode.INFRARED) 
				{
					_myRenderer.material.color -= new Color (0, 0, 0, Time.deltaTime);

				}
			}
			else
			{
				_myRenderer.material.color = new Color(_myColor.r, _myColor.g, _myColor.b, 0);
			}
		}
		else
		{
			_colorFlag = false;
			if(_myRenderer.material.color.a < _myColor.a)
			{
				_myRenderer.material.color += new Color(0,0,0, Time.deltaTime * 2);
			}
			else
			{
				_myRenderer.material.color = _myColor;
			}
		}
		_isRendered = false;
		Debug.Log(_myRenderer.material.color);
	}
	
 

	IEnumerator ColorChange()
	{
		int timeP = 0;
		int timeM = 0;
		float color = 0.01f;

//		_reRenderer = this.GetComponent<Renderer>(); 

		while (timeP < 600 && _colorFlag == true && color <= 1) {
			Debug.Log ("プラス");
			_myRenderer.material.SetColor ("_EmissionColor", new Color (0, color, 0));
			color += 0.01f;
			timeP++;
			yield return true;

			if (_lightButton._lightMode != LightMode.BLACK) {
				Debug.Log ("break");
				yield break;
			}
		}
		while (timeM < 600 && _colorFlag == false) {
			Debug.Log ("マイナス");
			_myRenderer.material.SetColor ("_EmissionColor", new Color (0, color, 0));
			color -= 0.01f;
			timeM++;
			yield return true;

			if (_lightButton._lightMode != LightMode.BLACK) {
				Debug.Log ("break");
				yield break;
			}
		}
	}
	/*
	IEnumerator ColorBack()
	{
		int time = 0;
		float color = 0.5f;
		while (time < 600) {
			if (_lightButton._lightMode == LightMode.BLACK)
			{
				Debug.Log ("break");
				yield break;
			}

			_myRenderer.material.SetColor ("_EmissionColor", new Color (0, color, 0));
			color -= 0.02f;
			time++;

			yield return true;
		}
	}
	*/
}
