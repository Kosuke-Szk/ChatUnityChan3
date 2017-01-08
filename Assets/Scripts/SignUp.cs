using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUp : MonoBehaviour {

	public InputField _nameField;
	public InputField _passwordField;
	public static string localhostUrl = "http://127.0.0.1:8000/api/accounts/";

	public void SendNamev3()
	{
		Debug.Log (localhostUrl);
		HTTP.Postv3 (localhostUrl, _nameField.text, _passwordField.text, www => {
			Debug.Log(www.text);
		}, www => {
			Debug.Log(www.error);
		});
	}
}
