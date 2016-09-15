using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
///		ライトの電池関係
/// </summary>
public class LightBatteryContorol : MonoBehaviour
{
    public SerialHandler serialHandler;
    private float dt = 0.0f;

	/// <summary>
	/// ライトボタンの保持
	/// </summary>
	[SerializeField]
	private LightButton _lightButton = null;

	/// <summary>
	///	バッテリーバー
	/// </summary>
	[SerializeField]
	private Image _batteryImage = null;

	[SerializeField]
	private List<Sprite> _batterySpr = new List<Sprite>();

	[SerializeField]
	private int initBatteryLevel = 100;

	/// <summary>
	/// バッテリー残量
	/// </summary>
	[SerializeField]
	private float _batteryLevel;

	/// <summary>
	/// バッテリーレベル　0以上100以下（整数）
	/// </summary>
	public float BatteryLevel
	{
		get { return _batteryLevel; }
		set
		{
			if(value < 0) { _batteryLevel = 0; }
			else if(value > 100) { _batteryLevel = 100; }
			else { _batteryLevel = value; }
		}
	}
	
	private float _lightPower;

	[SerializeField]
	private float _lightPowerMin;
	
	[SerializeField]
	private float _lightPowerMax;
	
	public float LightPower
	{
		get { return _lightPower; }
		set
		{
			if (value > _lightPowerMax) _lightPower = _lightPowerMax;
			else if (value < _lightPowerMin) _lightPower = _lightPowerMin;
			else _lightPower = value;
		}
	}

	/// <summary>
	/// 各ライトの電力消費量
	/// </summary>
	[SerializeField]
	private ElectricityConsumption _electricityConsumption = new ElectricityConsumption();
	
	private List<int> _electricityConsumptionList;
	void Start()
	{
		BatteryLevel = initBatteryLevel;
		_electricityConsumptionList = new List<int>()
		{
			_electricityConsumption.OFF,
			_electricityConsumption.NORMAL,
			_electricityConsumption.BLACK,
			_electricityConsumption.INFRARED
		};
	}
	
	//	1分(60sec)に何％消費するのかで計算
	void Update()
	{
		BatteryLevel -= (float)_electricityConsumptionList[(int)_lightButton._lightMode] / 60 * Time.deltaTime;

        dt += Time.deltaTime;
        //Debug.Log(dt);
        if (dt > 1.0f)
        {
            dt = 0.0f;
            //serialHandler.Write (((int)BatteryLevel).ToString ()+"¥r¥n");
            string s = ((int)BatteryLevel).ToString() + "\n";
            serialHandler.Write(s);
            Debug.Log(s);
        }

		for(int i = _batterySpr.Count - 1; i >= 0; i--)
		{
			if ((initBatteryLevel / _batterySpr.Count * i) < BatteryLevel)
			{
				_batteryImage.sprite = _batterySpr[i];
				break;
			}
		}


		//_batteryImage.fillAmount =  BatteryLevel * 0.01f;
		LightPower = BatteryLevel * 0.01f * 2f;
		_lightButton._light.intensity = LightPower;
	}

}

/// <summary>
/// 電力消費量	1分(60sec)に何％消費するのか
/// </summary>
[System.Serializable]
public class ElectricityConsumption
{
	[SerializeField]
	private int off;
	[SerializeField]
	private int normal;
	[SerializeField]
	private int black;
	[SerializeField]
	private int infrared;
	
	//	読み取り専用
	public int OFF { get {return off; } }
	public int NORMAL { get { return normal; } }
	public int BLACK { get { return black; } }
	public int INFRARED { get { return infrared; } }

}