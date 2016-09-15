using UnityEngine;
using System.Collections;

public enum blackMode
{
    TRANSPARENCY,
    FOOT,
    GREEN,
}

public class GimmickAction : MonoBehaviour
{
    //ゲームオブジェクトの指定
    public GameObject memo;
    public GameObject key;
    //	反応するライトの種類
    public LightMode respondLightMode;

    public GameObject _parent;

    //	特殊アクション
    public SpecialActionList specialAction;

    private bool F_lock = false;

    public bool objCheck = false;

    public blackMode blackLightMode;

    //	ライトのカメラのタグ名
    private const string LIGHT_CONTROLLER_CAMERA_TAG_NAME = "LightControllerCamera";

    //	ライトスクリプト
    public LightButton _lightButton;

    //	カメラに表示されているか
    public bool _isRendered = false;

    //	レンダラー
    private Renderer _myRenderer = null;
    //	色
    private Color _myColor;

    public float time;
    private float timer;
    public bool _colorFlag = false;

    void Start()
    {
        //	レンダラーを取得
        _myRenderer = this.GetComponent<Renderer>();
        //初めの色を_myColorに格納
        _myColor = _myRenderer.material.color;

        switch (respondLightMode)
        {
            case LightMode.BLACK:
                _myColor.a = 0f;
                break;
        }

    }
    private void OnWillRenderObject()
    {
        //	カメラに映った時だけ _isRendered を有効に
        if (Camera.current.tag == LIGHT_CONTROLLER_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }

    void Update()
    {
        //	もし映っているならば
        if (_isRendered)
        {
            if (_myRenderer.material.color.a >= 0)
            {
                Debug.Log("いすとらえた");
                if (respondLightMode == _lightButton._lightMode)
                {
                    switch (respondLightMode)
                    {
                        case LightMode.NORMAL:
                            //	acrtion
                            Debug.Log("のーまる");
                            toyMove();
                            break;
                        case LightMode.BLACK:
                            //	acrtion
                            Debug.Log("ぶらっく");
                            if (_myRenderer.material.color.a >= 0)
                            {

                                _colorFlag = true;
                                StartCoroutine(black());
                                if (objCheck == true)
                                {
                                    memo.SetActive(true);
                                    key.SetActive(true);
                                }
                            }
                            else
                            {
                                _colorFlag = false;
                            }
                            if (_lightButton._lightMode != LightMode.BLACK)
                            {
                                _myRenderer.material.color = _myColor;
                            }
                            break;
                        case LightMode.INFRARED:
                            //	acrtion
                            Debug.Log("ろすと");
                            lost();
                            break;
                        case LightMode.OFF:
                            //	acrtion
                            Debug.Log("おふ");
                            off();
                            break;

                        default: break;
                    }
                }
                else
                {
                    F_lock = false;
                    _colorFlag = false;
                    _myRenderer.material.color = _myColor;
                }
            }
        }
        else
        {
            F_lock = false;
            _colorFlag = false;
            _myRenderer.material.color = _myColor;
        }
        _isRendered = false;
    }
    void toyMove()
    {
        Animator par = _parent.GetComponent<Animator>();
        par.enabled = (true);
        // GetComponent<Animator>().enabled = true;
    }

    void lost()
    {
        Debug.Log("消したい");
        _myRenderer.material.color = new Color(_myColor.r, _myColor.g, _myColor.b, 0f);
    }
    void off()
    {
        _myRenderer.material.color = new Color(_myColor.r, _myColor.g, _myColor.b, 255f);
    }

    private IEnumerator black()
    {
        Color _color = _myRenderer.material.color;
        //	見ている間アルファをプラス
        int timeP = 0;
        int timeM = 0;
        float color = 0.01f;
        float green = 0.01f;

        //		_reRenderer = this.GetComponent<Renderer>(); 
        if (F_lock == false)
        {
            while (timeP < 600 && _colorFlag == true && color <= 1 && green <= 1)
            {
                F_lock = true;
                Debug.Log("プラス");
                //_myRenderer.material.color =  new Color(_color.r,green,_color.b,color);
                switch (blackLightMode)
                {
                    case blackMode.TRANSPARENCY:
                        _myRenderer.material.color = new Color(_color.r, _color.g, _color.b, color);
                        color += 0.01f;
                        break;
                    case blackMode.GREEN:
                        _myRenderer.material.SetColor("_EmissionColor", new Color(0, green, 0));
                        green += 0.01f;
                        break;
                    case blackMode.FOOT:
                        _myRenderer.material.color = new Color(_color.r, _color.g, _color.b, 255);
                        break;
                }
                timeP++;

                if (_lightButton._lightMode != LightMode.BLACK)
                {
                    _myRenderer.material.color = _myColor;
                    green = 0;
                    color = 0;
                    F_lock = false;
                    //Debug.Log("break");
                    yield break;
                }

                yield return true;
            }
            /*  switch (blackLightMode)
                {
                    case blackMode.TRANSPARENCY:
                        _myRenderer.material.color = new Color(_color.r, _color.g, _color.b, 255f);
                        break;
                    case blackMode.GREEN:
                        _myRenderer.material.SetColor("_EmissionColor", new Color(0, 1, 0));
                        break;
                }*/

            //yield break;
        }
        while (timeM < 600 && _colorFlag == false)
        {
            Debug.Log("マイナス");
            _myRenderer.material.color = new Color(_color.r, _color.g, _color.b, color);
            color -= 0.01f;
            timeM++;
            yield return true;

            if (_lightButton._lightMode != LightMode.BLACK || color <= 0)
            {
                Debug.Log("break");
                yield break;
            }
        }
        yield break;
    }
}
