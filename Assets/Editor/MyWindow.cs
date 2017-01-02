using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow: EditorWindow 
{

	string myString = "http://127.0.0.1:8000/titles";
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
			Debug.Log("ボタン押したよ！");
		}
		if(GUILayout.Button("http://localhost:8000/api/articles"))
		{
			Debug.Log("ボタン押したよ！");
		}
		myString = EditorGUILayout.TextField ("LocalhostURL", myString);

		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
	}
}
