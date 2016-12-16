using UnityEngine;
using System.Collections;

public class LogPanel : MonoBehaviour 
{
	public void OnPressLogBtn()
	{
		if (!this.gameObject.activeSelf) {
			this.gameObject.SetActive (true);
		} else {
			this.gameObject.SetActive (false);
		}

	}

}
