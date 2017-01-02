using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow: EditorWindow 
{

	string LocalHostTitles = "http://127.0.0.1:8000/titles";
	string LocalHostArticles = "http://localhost:8000/api/articles";
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
		if(GUILayout.Button("http://127.0.0.1:8000/titles"))
		{
			currentUrl = LocalHostTitles;
			currentUrl = EditorGUILayout.TextField ("LocalhostURL", currentUrl);
			SignIn.URL = currentUrl;
			Debug.Log ("URLは" + SignIn.URL.ToString());
		}
		if(GUILayout.Button("http://localhost:8000/api/articles"))
		{
			currentUrl = LocalHostArticles;
			currentUrl = EditorGUILayout.TextField ("LocalhostURL", currentUrl);
			SignIn.URL = currentUrl;
			Debug.Log ("URLは" + SignIn.URL.ToString());
		}
		currentUrl = EditorGUILayout.TextField ("LocalhostURL", currentUrl);

		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
	}
}
