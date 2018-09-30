using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerOnTrigger : MonoBehaviour {

	//CODE BELOW WORKS
	// Use this for initialization
	public GameObject character;
	private Animator animator;
	//public bool isBool;
	public string variable;
	public bool isLeftRight;
	public float time;
	bool hasFinished = false;
	void Start () {
		animator = character.GetComponent<Animator>();
		//if (isLeftRight) {
			animator.SetBool (variable, true);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		time--;
		if (isLeftRight) {
			character.transform.position = new Vector3 (character.transform.position.x + 0.3f, character.transform.position.y, character.transform.position.z);
		}
		if (time <= 0) {
			animator.SetBool(variable, false);
			hasFinished = true;
			Destroy (this.gameObject);
		}
	}
}
