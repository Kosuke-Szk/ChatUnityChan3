using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllertPanel : MonoBehaviour {

	public GameObject _loginAllertPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPressCloseBtn()
	{
		if (_loginAllertPanel.activeSelf) 
		{
			_loginAllertPanel.gameObject.SetActive (false);
		}
	}
}
