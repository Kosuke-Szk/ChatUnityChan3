using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnPressSignInBtn()
	{
		if (!this.gameObject.activeSelf) 
		{
			this.gameObject.SetActive (true);
		}
	}

	public void OnPressCancelBtn()
	{
		if (this.gameObject.activeSelf) 
		{
			this.gameObject.SetActive (false);
		}
	}
}
