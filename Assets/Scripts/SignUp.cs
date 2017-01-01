using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUp : MonoBehaviour {

	public InputField _titleField;
	public InputField _writerNumber;
	public InputField _contentsField;
	private string localhostUrl = "http://localhost:8000/api/articles.json";

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SendName()
	{
		HTTP.TestPost (localhostUrl, _writerNumber.text, _titleField.text, _contentsField.text,www => {
			Debug.Log(www.text);
		}, www => {
			Debug.Log(www.error);
		});
	}
}
