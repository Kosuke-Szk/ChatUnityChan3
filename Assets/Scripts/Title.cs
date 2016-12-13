using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPressARBtn()
    {
        SceneManager.LoadScene("AR_Main");
    }

    public void OnPressNormalBtn()
    {
        SceneManager.LoadScene("Normal_Main");
    }
}
