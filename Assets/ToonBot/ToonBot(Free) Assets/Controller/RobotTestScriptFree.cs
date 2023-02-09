using UnityEngine;
using System.Collections;

public class RobotTestScriptFree : MonoBehaviour {

	private Animator anim;

	void Start () {
	
		anim = this.gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		//Controls the Input for running animations
		// 1: walk
		//2: Run
		//3: Jump
			
		if(Input.GetKey("2")) anim.SetInteger("Speed", 2);
			else if(Input.GetKey("1")) anim.SetInteger("Speed", 1);
				else anim.SetInteger("Speed", 0);
	}
}
