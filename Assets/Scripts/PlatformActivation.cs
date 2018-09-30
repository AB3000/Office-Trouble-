using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivation : MonoBehaviour {

	public PlayerController player;
	//public 
	public float xOffset, yOffset;
	public bool canChange;
	public bool isUpDown;
	//public GameObject currentPlatform;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

	}

	// Update is called once per frame
	void Update () {
		/*if (player.transform.position.y - yOffset > this.transform.position.y) {
			this.GetComponent<BoxCollider2D> ().enabled = true;
		} else {
			this.GetComponent<BoxCollider2D> ().enabled = false;
		} THIS CODE WORKS*/

		if (isUpDown) {
			if (player.transform.position.y - yOffset > this.transform.position.y) {
				/*if(this.gameObject.name == "bed")
			   Debug.Log ("Player can collide with desk");*/
				Physics2D.IgnoreCollision (player.GetComponent<BoxCollider2D> (), this.GetComponent<BoxCollider2D> (), false);

			} else {
				/*if(this.gameObject.name == "bed")
				Debug.Log ("Currently ignoring collision for the desk");*/
				Physics2D.IgnoreCollision (player.GetComponent<BoxCollider2D> (), this.GetComponent<BoxCollider2D> (), true);

			}
		} else {
			if (player.transform.position.x - xOffset > this.transform.position.x) {
				/*if(this.gameObject.name == "bed")
			   Debug.Log ("Player can collide with desk");*/
				Physics2D.IgnoreCollision (player.GetComponent<BoxCollider2D> (), this.GetComponent<BoxCollider2D> (), false);

			} else {
				/*if(this.gameObject.name == "bed")
				Debug.Log ("Currently ignoring collision for the desk");*/
				Physics2D.IgnoreCollision (player.GetComponent<BoxCollider2D> (), this.GetComponent<BoxCollider2D> (), true);

			}
		}


		if (canChange && Input.GetKeyDown (KeyCode.Return)) {
			Physics2D.IgnoreCollision (player.GetComponent<BoxCollider2D> (), this.GetComponent<BoxCollider2D> (), true);
		}
	}



		
}
