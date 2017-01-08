using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow: EditorWindow 
{
	string LocalHostv3 = "http://127.0.0.1:8000/api/accounts";
	string SignInHost = "http://127.0.0.1:8000/usernames";
	string SignInHerokuHost = "https://afternoon-headland-57954.herokuapp.com/api/accounts/";
	private static string currentUrl = "";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;

	[MenuItem("Window/KOSUKE")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(MyWindow));
	}

	void OnGUI()
	{
		GUILayout.Label ("Webhook URL Settings", EditorStyles.boldLabel);
		if(GUILayout.Button("http://127.0.0.1:8000/api/accounts"))
		{
			currentUrl = LocalHostv3;
			currentUrl = EditorGUILayout.TextField ("LocalhostURL", currentUrl);
			SignIn.URL = currentUrl;
			SignUp.localhostUrl = currentUrl;
			Debug.Log ("URLは" + SignIn.URL.ToString());
		}
		if(GUILayout.Button("http://127.0.0.1:8000/usernames"))
		{
			currentUrl = SignInHost;
			currentUrl = EditorGUILayout.TextField ("LocalhostURL", currentUrl);
			SignIn.URL = currentUrl;
			SignUp.localhostUrl = currentUrl;
			Debug.Log ("URLは" + SignIn.URL.ToString());
		}
		if(GUILayout.Button("Staging環境に設定"))
		{
			currentUrl = SignInHerokuHost;
			currentUrl = EditorGUILayout.TextField ("LocalhostURL", currentUrl);
//			SignIn.URL = currentUrl;
			SignUp.localhostUrl = currentUrl;
			Debug.Log ("URLは" + SignIn.URL.ToString());
		}
		currentUrl = EditorGUILayout.TextField ("LocalhostURL", currentUrl);
	}
}
