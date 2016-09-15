using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.SerializableAttribute]
public class Mes
{	
	[SerializeField]
	public int ID;
	[SerializeField]
	public string Text;
}

public enum MASSAGE_NO
{
	NULL = -1,
	ID,
	TEXT
}

public class Message : MonoBehaviour
{
	[SerializeField]
	TextAsset SystemMesCsv;

	[SerializeField]
	TextAsset TalkMesCsv;
	
	[SerializeField]
	TextAsset HintMesCsv;

	[SerializeField]
	public static List<Mes> list_systemMesList = new List<Mes>();

	[SerializeField]
	public static List<Mes> list_talkMesList = new List<Mes>();

	[SerializeField]
	public static List<Mes> list_hintMesList = new List<Mes>();

	void Start()
	{
		list_systemMesList = createMassage(SystemMesCsv);
		list_talkMesList = createMassage(TalkMesCsv);
		list_hintMesList = createMassage(HintMesCsv);

	}

	private List<Mes> createMassage(TextAsset textData)
	{
		List<Mes> mesList = new List<Mes>();
		List<string[]> textList = ReadCSV.readCsv(textData);

		for (int i = 0; i < textList.Count; i++)
		{
			Mes mes = new Mes();
			mes.ID = int.Parse(textList[i][(int)MASSAGE_NO.ID]);
			mes.Text = textList[i][(int)MASSAGE_NO.TEXT];

			mesList.Insert(i, mes);
		}
		return mesList;
	}



}
