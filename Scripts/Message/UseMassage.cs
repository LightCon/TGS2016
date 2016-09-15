using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public enum MES_TYPE
{
	NULL,
	SYSTEM,
	HINT,
	TALK
}

public class UseMassage : MonoBehaviour {

	public Text TextBox;
	public Text HintBox;

	public Text[] textWin;

	public string getMassage(MES_TYPE _mes_type,int _ID)
	{
		//string ans = "";
		switch(_mes_type)
		{
			case MES_TYPE.SYSTEM:
				return Message.list_systemMesList[_ID - 1].Text;
			case MES_TYPE.HINT:
				return Message.list_hintMesList[_ID - 1].Text;
			case MES_TYPE.TALK:
				return Message.list_talkMesList[_ID - 1].Text;
		}
		return "エラー";
	}

	public void setMassage(MES_TYPE _mes_type, int _ID)
	{
		textWin[(int)_mes_type].text = getMassage(_mes_type, _ID);
	}

}
