using UnityEngine;
using System.Collections;
using UnityChan;

public class Smile : MonoBehaviour {

    private FaceUpdate faceChange;
    public GameObject chatBot;
    Animator animator;

	void Start () 
    {
        animator = chatBot.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPressSmile()
    {
        animator.SetTrigger("Jump");
    }
}
