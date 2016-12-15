using UnityEngine;
using System.Collections;

public class FaceChange : MonoBehaviour {

    Animator animator;
    public GameObject chatbot;
    private bool isSmile;
    private bool isAngry;

	void Start () {
        animator = chatbot.GetComponent<Animator>();
	
	}
	
	void Update () {
	
	}

    public void OnCallSmile()
    {
        if (!isSmile)
        {
            animator.SetBool("Smile", true);
            isSmile = true;
        } else
        {
            animator.SetBool("Smile", false);
            isSmile = false;
        }
    }

    public void OnCallAngry()
    {
        
    }
}
