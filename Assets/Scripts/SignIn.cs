using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using UnityEngine.UI;

public class SignIn : MonoBehaviour {

	private string localhostUrl = "http://localhost:8000/api/articles.json";
	private string localhostTesturl = "http://127.0.0.1:8000/titles";
	public InputField _nameInput;
	public Text _confirmMessage;
	public GameObject loginConfirmPanel;
	public GameObject loginAllertPanel;
	public static string inputname = "";

	public static string URL = "";


	//getter
	public static string getInputName()
	{
		return inputname;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnPressLoginBtn()
	{
		
	}

	public void OnPressTestBtn()
	{
		HTTP.Get (URL, www => {
			Debug.Log(www.text);
			string[] stArray = www.text.Split(',');
			for (int i = 0; i < stArray.Length; i++)
			{
				Debug.Log(stArray[i]);
			}
//			var jsonDict = Json.Deserialize(www.text) as Dictionary<string,object>;

		},www => {
			Debug.Log(www.error);
		});
	}

	public void OnPressLogInBtn()
	{
		inputname = _nameInput.text;
		bool isName = false;

		if (inputname != "") {
			HTTP.Get (URL, www => {
				string[] stNames = www.text.Split (',');
				for (int i = 0; i < stNames.Length; i++) {
					Debug.Log (stNames [i]);
					if (inputname == stNames [i]) {
						isName = true;
					}
				}
				if (isName) {
					Debug.Log ("こんにちは" + inputname + "さん");
					_confirmMessage.text = "こんにちは!" + inputname + "さん";
					if (!loginConfirmPanel.activeSelf) {
						loginConfirmPanel.gameObject.SetActive (true);
					}
				} else {
					Debug.Log ("ユーザー登録してください");
					if (!loginAllertPanel.activeSelf) {
						loginAllertPanel.gameObject.SetActive (true);
					}
				}
			}, www => {
				Debug.Log (www.error);
			});
		} else {
			return;
		}
	}
}
