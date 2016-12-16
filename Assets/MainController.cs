using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
	public GameObject _normalSystem;
	public GameObject _ARsystem;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPressNormalBtn()
	{
		_normalSystem.SetActive (true);
		_ARsystem.SetActive (false);
	}

	public void OnPressARBtn()
	{
		_normalSystem.SetActive (false);
		_ARsystem.SetActive (true);
	}

	public void OnPressShiritoriBtn()
	{
		
	}
}
