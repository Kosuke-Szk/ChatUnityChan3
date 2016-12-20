﻿using UnityEngine;
using System.Text;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using LitJson;
using MiniJSON;
using UnityChan;


public class Chatbot : MonoBehaviour 
{
	string str;
	public InputField inputField;
	private string DOCOMO_API_KEY = "6255615075614d4a3455552f57546d583366686d3332314746456e6e49714a49464d43325a667561685a33";
	private string DOCOMO_ENDPOINT = "https://api.apigw.smt.docomo.ne.jp/dialogue/v1/dialogue";
	private string Local_webhook = "http://localhost:8000/api/articles/1.json";
	private string API_Post_Url {get { return "https://api.apigw.smt.docomo.ne.jp/dialogue/v1/dialogue?=6255615075614d4a3455552f57546d583366686d3332314746456e6e49714a49464d43325a667561685a33";}}
	private Hashtable Headers {
		get { 
			var headers = new Hashtable ();
			headers["APIKEY"]= DOCOMO_API_KEY;
			headers ["Content-Type"] = "application/json";
			return headers;
		}
	}
	public GameObject fukidashi;
	public GameObject parentObject;

	public GameObject _userSpeech;
	public GameObject _userSpeechParent;
	private FaceUpdate faceUpdate;
	private Animator _animator;

	public Text _userLog;
	public Text _unityChanLog;

	private string userSaveLog;
	private string unitySaveLog;

	private string contextId = "";

	void Start () 
	{
		_animator = GetComponent<Animator> ();
		unitySaveLog = "\n";
	}

	void Update () {
	}

	public void OnPressSendBtn()
	{
		var url = DOCOMO_ENDPOINT +"?"+ "APIKEY="+ DOCOMO_API_KEY;
		string sendMessage = inputField.text;

		Vector3 userPos = _userSpeechParent.transform.position;
		GameObject userSpeech = (GameObject)Instantiate (_userSpeech, userPos, Quaternion.Euler(0,180,0));
		userSpeech.transform.parent = _userSpeechParent.transform;
		Text userTalk = GameObject.Find ("UserTalk").GetComponent<Text> ();
		userTalk.text = sendMessage;
		userSaveLog = WriteUserLog (sendMessage, userSaveLog);


		HTTP.Post (url, sendMessage, contextId,www => {
			Debug.Log (www.text);
			Vector3 pos = parentObject.transform.position;
			GameObject prefab = (GameObject)Instantiate(fukidashi, pos, Quaternion.identity);
			prefab.transform.parent = parentObject.transform;
			Text botTalk =  GameObject.Find("BotTalk").GetComponent<Text>();
			var resJson = (IDictionary)MiniJSON.Json.Deserialize(www.text);
			string botResponse = (string)resJson["utt"];
			Debug.Log("1 : "+contextId);
			contextId = (string)resJson["context"];
			Debug.Log("2 :"+contextId);
			Debug.Log(botResponse);
			botTalk.text = botResponse;
			SpeakScript.Speak(botResponse);
			unitySaveLog = WriteUnityChanLog(botResponse, unitySaveLog);
			ChangeAnimation();
		}, www => {
			Debug.Log (www.error);
		});
		inputField.text = "";
	}

	IEnumerator Get(string url)
	{
		Hashtable header = new Hashtable ();
		header.Add ("Accept-Language", "ja");
		header.Add ("Content-Type", "application/json");

		WWW www = new WWW (url);
		yield return www;

		if (www.error == null) {
			Debug.Log ("Get Success"+www.text);
			var resJson = (IDictionary)MiniJSON.Json.Deserialize(www.text);
			string botResponse = (string)resJson["title"];
			Debug.Log (botResponse);
		} else 
		{
			Debug.Log ("Get Failure");
			string botResponse = "";
		}
	}

	public void OnCallGetMethod()
	{
		StartCoroutine (Get (Local_webhook));

	}

	public void ChangeAnimation()
	{
		_animator.SetTrigger ("Send");

	}

	public string WriteUserLog(string input, string saveLog)
	{
		saveLog += "\n\n" + "あなた: " + input;
		_userLog.text = saveLog;
		return saveLog;
	}

	public string WriteUnityChanLog(string input, string saveLog)
	{
		saveLog += "\n\n" + "Unityちゃん: " + input;
		_unityChanLog.text = saveLog;
		return saveLog;
	}

	public void OnEndEdit()
	{
		var url = DOCOMO_ENDPOINT +"?"+ "APIKEY="+ DOCOMO_API_KEY;
		string sendMessage = inputField.text;
		Vector3 userPos = _userSpeechParent.transform.position;
		GameObject userSpeech = (GameObject)Instantiate (_userSpeech, userPos, Quaternion.Euler(0,180,0));
		userSpeech.transform.parent = _userSpeechParent.transform;
		Text userTalk = GameObject.Find ("UserTalk").GetComponent<Text> ();
		userTalk.text = sendMessage;
		userSaveLog = WriteUserLog (sendMessage, userSaveLog);


		HTTP.Post (url, sendMessage, contextId,www => {
			Debug.Log (www.text);
			Vector3 pos = parentObject.transform.position;
			GameObject prefab = (GameObject)Instantiate(fukidashi, pos, Quaternion.identity);
			prefab.transform.parent = parentObject.transform;
			Text botTalk =  GameObject.Find("BotTalk").GetComponent<Text>();
			var resJson = (IDictionary)MiniJSON.Json.Deserialize(www.text);
			string botResponse = (string)resJson["utt"];
			Debug.Log(botResponse);
			botTalk.text = botResponse;
			SpeakScript.Speak(botResponse);
			unitySaveLog = WriteUnityChanLog(botResponse, unitySaveLog);
			ChangeAnimation();
		}, www => {
			Debug.Log (www.error);
		});
	}
}
