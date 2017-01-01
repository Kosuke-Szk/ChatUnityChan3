using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour 
{
	private GameObject signUpPopup;
	// Use this for initialization
	void Start () 
	{
		GameObject signUpPopup = GameObject.Find ("SignUpPopup");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnPressSignUpBtn()
	{
		if (!signUpPopup.gameObject.activeSelf) {
			signUpPopup.gameObject.SetActive (true);
		} else {
			signUpPopup.gameObject.SetActive (false);
		}
	}

	public void OnPressSignInBtn()
	{
		
	}
}
