using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HTTP : MonoBehaviour {
	private static HTTP instance;

	private string DOCOMO_API_KEY = "6255615075614d4a3455552f57546d583366686d3332314746456e6e49714a49464d43325a667561685a33";
	private string DOCOMO_ENDPOINT = "https://api.apigw.smt.docomo.ne.jp/dialogue/v1/dialogue";




	//Sigleton
	private HTTP(){}

	static HTTP Instance 
	{
		get 
		{
			if (instance == null) 
			{
				GameObject go = new GameObject ("HTTPSingleton");
				instance = go.AddComponent<HTTP> ();
			}
			return instance;
		}
	}

	public static WWW Get(string url, Action<WWW> onSuccess, Action<WWW> onError = null)
	{
		WWW www = new WWW(url);
		Instance.StartCoroutine (Instance.WaitForRequest (www, onSuccess, onError));
		return www;
	}

	public static WWW Post(string url, string input, string id, Action<WWW> onSuccess, Action<WWW> onError = null)
	{
		Debug.Log ("IDは"+id);
		var data = new 
		{
			utt = input,
			context = id
		};
		Debug.Log("data is :" + data);
		string json = LitJson.JsonMapper.ToJson (data);

		var send = System.Text.Encoding.Unicode.GetBytes (json);
		WWWForm form = new WWWForm ();
		var headers = form.headers;
		headers["Content-Type"]= "application/json";

		Debug.Log (headers ["Content-Type"]);

		WWW www = new WWW (url, send, headers);
		Instance.StartCoroutine (Instance.WaitForRequest (www, onSuccess, onError));
		return www;
	}

	public static WWW ServerPost(string url, string writerInput, string titleInput, string contentsInput, Action<WWW> onSuccess, Action<WWW> onError = null )
	{
		var data = new{
			writer = writerInput,
			title = titleInput,
			contents = contentsInput
		};
		string json = LitJson.JsonMapper.ToJson (data);

//		string json = "writer=" + writerInput + "&title=" + titleInput + "&contents=" + contentsInput;

		var send = System.Text.Encoding.Unicode.GetBytes (json);
		Debug.Log (send);
		WWWForm form = new WWWForm ();
		var headers = form.headers;
		headers["Content-Type"]= "application/json";

		Debug.Log (headers ["Content-Type"]);

		WWW www = new WWW (url, send, headers);
		Instance.StartCoroutine (Instance.WaitForRequest (www, onSuccess, onError));
		return www;
	}

	public static WWW TestPost(string url, string writerInput, string titleInput, string contentsInput,Action<WWW> onSuccess, Action<WWW> onError = null)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("writer", writerInput);
		form.AddField ("title", titleInput);
		form.AddField ("contents", contentsInput);
		WWW www = new WWW (url, form);
		Instance.StartCoroutine (Instance.WaitForRequest (www, onSuccess, onError));
		return www;
	}

	public static WWW Postv3(string url,string nameInput, string passwordInput, Action<WWW> onSuccess, Action<WWW> onError = null)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("user", "1");
		form.AddField ("username", nameInput);
		form.AddField ("password", passwordInput);
		WWW www = new WWW (url, form);
		Instance.StartCoroutine (Instance.WaitForRequest (www, onSuccess, onError));
		return www;
	}


	IEnumerator WaitForRequest(WWW www, Action<WWW> onSuccess, Action<WWW> onError)
	{
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			Debug.Log ("WWW OK! :" + www.text);
			onSuccess (www);
		} else {
			Debug.Log ("WWW Error :" + www.error);
			if (onError != null)
				onError (www);
		}
	}
}
