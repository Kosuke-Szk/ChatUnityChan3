using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollContent : MonoBehaviour {

	[SerializeField]
	RectTransform unityNode = null;

	[SerializeField]
	RectTransform userNode = null;

	public GameObject _chatLog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateUnityNode(string talk)
	{
		var item = GameObject.Instantiate (unityNode) as RectTransform;
		item.SetParent (transform, false);
		var text = item.GetComponentInChildren<Text> ();
		text.text = "UnityChan: " + talk;
	}

	public void CreateUserNode(string talk)
	{
		var item = GameObject.Instantiate (userNode) as RectTransform;
		item.SetParent (transform, false);
		var text = item.GetComponentInChildren<Text> ();
		text.text = "あなた: " + talk;
	}

	public void OnPressCloseBtn()
	{
		if (_chatLog.activeSelf) 
		{
			_chatLog.SetActive (false);
		}
	}

	public void OnPressLogPanelBtn()
	{
		if (!_chatLog.activeSelf) 
		{
			_chatLog.SetActive (true);
		}
	}
		
}
