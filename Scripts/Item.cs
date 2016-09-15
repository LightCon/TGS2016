using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
///	アイテムタイプ
/// </summary>
public enum ITEM_TYPE
{
	NULL = -1,
	LIGHT,	//	ライト
	KEY,	//	鍵
	MEMO,	//	メモ
	BATTERY,	//	電池
    BOX,        //　びっくり箱
    FABO,       //　ファヴォッティー
	NUM
}

public class Item : MonoBehaviour
{

    public LightButton _lightButton;

    // オブジェクトの選択
    public GameObject gameObj;
    public GameObject gameObj2;
    public GameObject gameObj3;

    public GameObject bikkuri;
    private AudioSource bikkuri_AudioSource;

    public Animator anim;
	/// <summary>
	/// アイテムの種類
	/// </summary>
	public ITEM_TYPE item_type;

	/// <summary>
	/// メモの番号
	/// </summary>
	public int memoNo;

	/// <summary>
	///	通常時のマテリアル
	/// </summary>
	private Material MT_normal;

	/// <summary>
	/// 選択中のマテリアル
	/// </summary>
	public Material MT_selecting;

	/// <summary>
	/// ライトに付けているカメラのタグ名
	/// </summary>
	private const string LIGHT_CONTROLLER_CAMERA_TAG_NAME = "LightControllerCamera";

	/// <summary>
	/// カメラに表示されているか
	/// </summary>
	public bool isRendered;

	/// <summary>
	/// タイマー
	/// </summary>
	public float timer = 0f;
	/// <summary>
	/// 注視する時間
	/// </summary>
	public float timer_limit = 3f;

	/// <summary>
	/// UIでのメモの表示場所
	/// </summary>
	public Image itemView;

	/// <summary>
	/// メモのスプライト
	/// </summary>
	public Memo memoSpr;

	/// <summary>
	///	アイテムを表示する時間
	/// </summary>
	public float itemViewTime;

	/// <summary>
	/// バッテリーの容量
	/// </summary>
	[SerializeField]
	private int battery = 33;

	/// <summary>
	///	フラグマネージャーの保持
	/// </summary>
	public FlagManager flagManager = null;

	void Start()
	{
		
		if (item_type == ITEM_TYPE.MEMO)
		{
			//	アイテム拡大表示をオフ
			itemView.gameObject.SetActive(false);
			//	IDに沿ったテクスチャに張替え
			this.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", memoSpr.Tex_memo[memoNo]);
			MT_selecting = Instantiate(MT_selecting);
			MT_selecting.SetTexture("_MainTex", memoSpr.Tex_memo[memoNo]);

		}
		//	元のマテリアルの取得
        if (item_type == ITEM_TYPE.FABO)
        {
            MT_normal = this.GetComponent<SkinnedMeshRenderer>().material;
        }
        else
            MT_normal = this.GetComponent<MeshRenderer>().material;
		
	}

	void Update()
	{
		//	ライトで見ている場合マテリアルを変更する
		if (item_type != ITEM_TYPE.LIGHT) changeMaterial(isRendered);

		if(timer > timer_limit)
		{
			getItem();
			timer = 0;
		}


		if (isRendered)
		{
			timer += Time.deltaTime;
		}
		else
		{
			timer = 0;
		}
		isRendered = false;
	}

	private void OnWillRenderObject()
	{
		//	カメラに映った時だけ _isRendered を有効に
		if (Camera.current.tag == LIGHT_CONTROLLER_CAMERA_TAG_NAME)
		{
			isRendered = true;
		}
	}

  

	/// <summary>
	/// マテリアルの張替え
	/// </summary>
	/// <param name="select">選択中か</param>
	void changeMaterial(bool _select)
	{
        if (item_type == ITEM_TYPE.FABO)
        {
            var meshRenderer = this.GetComponent<SkinnedMeshRenderer>();
            meshRenderer.material = _select ? MT_selecting : MT_normal;
        }
        else
        {
            var meshRenderer = this.GetComponent<MeshRenderer>();
            meshRenderer.material = _select ? MT_selecting : MT_normal;
        }		
	}

	void getItem()
	{
		switch(item_type)
		{
			case ITEM_TYPE.MEMO:
				{
					switch ((MEMO_FLAG)memoNo)
					{
						case MEMO_FLAG.MEMO_01:     //お
							//	最初のメモはライト取得後に取得できる
						    flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.SLIDE_DOOR, true);
                            //仮のフラグ立て
                            //flagManager.setFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_OPENEDJACK_IN_THE_BOX, true);
						    StartCoroutine(ViewItem());
							
							break;
						case MEMO_FLAG.MEMO_02:     //たん    ちゃぶ台
							if(flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_01))
							//flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.LIVING_DOOR, true);
							StartCoroutine(ViewItem());
							break;
						case MEMO_FLAG.MEMO_03:     //じょ    糸
							flagManager.setFlag(FLAG.GIMMICK, (int)GIMMICK_FLAG.IS_FOUND_YARN, true);
							StartCoroutine(ViewItem());
							break;
                        case MEMO_FLAG.MEMO_04:     //う     靴の下
                            gameObj.SetActive(true);
                            StartCoroutine(ViewItem());
                            break;
                        case MEMO_FLAG.MEMO_05:     //び     ビックリ箱
                            gameObj.SetActive(true);
                            StartCoroutine(ViewItem());                            
                            break;
                        case MEMO_FLAG.MEMO_06:     //お     ファボッティ
                            if (flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_05))
                            {
                                Debug.Log("kiteru");
                                flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.MY_ROOM_DOOR, true);
                                gameObj.SetActive(true);
                                gameObj2.SetActive(false);
                                gameObj3.SetActive(true);
                                StartCoroutine(ViewItem());
                            }                            
                            
                            break;
                        case MEMO_FLAG.MEMO_07:     //め     ぬいぐるみ
                            if (flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_06))
                            {
                                flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.BROTHERS_ROOM_DOOR, true);
                            }
                            StartCoroutine(ViewItem());
                            break;
                        case MEMO_FLAG.MEMO_08:     //で     かぎ
                            if (flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_07))
                            {
                                flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.PARENTS_ROOM_DOOR, true);
                                gameObj.SetActive(true);
                                Destroy(gameObj2);
                                gameObj3.SetActive(true);
                            }
                            StartCoroutine(ViewItem());
                            break;
                        case MEMO_FLAG.MEMO_09:     //と     ダンシングフラワー
                            if (flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_08))
                            {
                                gameObj.SetActive(true);
                                //flagManager.setFlag(FLAG.DOOR, (int)DOOR_FLAG.PARENTS_ROOM_DOOR, true);
                            }
                            StartCoroutine(ViewItem());
                            break;
                        case MEMO_FLAG.MEMO_10:     //う     ファボッティー
                            if (flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_09))
                            {
                                gameObj.SetActive(true);
                                gameObj3.SetActive(true);
                                Destroy(gameObj2);
                            }
                            StartCoroutine(ViewItem());
                            break;

						default:
							StartCoroutine(ViewItem());
							break;
					}
					flagManager.setFlag(FLAG.MEMO, memoNo, true);
					Debug.Log(flagManager.getFlag(FLAG.MEMO, memoNo));
					break;
				}
			case ITEM_TYPE.BATTERY:
				GameObject.FindWithTag("LightControl").GetComponent<LightBatteryContorol>().BatteryLevel += battery;
				Destroy(gameObject);
				break;
            case ITEM_TYPE.BOX:
                bikkuri_AudioSource = bikkuri.GetComponent<AudioSource>();
                bikkuri_AudioSource.Play();
                anim.SetTrigger("Ban");
                
                //checkExitAnimation();
                
                break;
            case ITEM_TYPE.FABO:
                gameObj.SetActive(true);
                Debug.Log("RMT");
                if (flagManager.getFlag(FLAG.MEMO, (int)MEMO_FLAG.MEMO_09))
                    if (_lightButton._lightMode == LightMode.INFRARED)
                    {
                        gameObj2.SetActive(true);
                        gameObj3.SetActive(true);
                    }
                break;
            
			default:
				flagManager.setFlag(FLAG.ITEM, (int)item_type, true);
				timer = 0;
				Destroy(gameObject);
				break;
		}

	}

    void checkExitAnimation()
    {
        AnimatorStateInfo animInfo;
        while(true)
        {
            animInfo = GameObject.FindWithTag("Happy").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            if (animInfo.normalizedTime <= 0.9f)
            {
                Debug.Log("114514");
            }
            else break;
        }
        gameObj.SetActive(true);
    }

    private void invoke(string p)
    {
        throw new System.NotImplementedException();
    }

	IEnumerator ViewItem()
	{
		itemView.sprite = memoSpr.Spr_memo[memoNo];
		itemView.gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();

		yield return new WaitForSeconds(itemViewTime);
		itemView.gameObject.SetActive(false);
		//Destroy(gameObject);
		
	}

}
