using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingObject : MonoBehaviour {

	public bool isFrozenType;
	public string platformName;
	public string changerName;
	public GameObject newSprite;
	public PlayerController player;
	public bool isClickable;
	// Use this for initialization
	void Start () {
		newSprite = GameObject.Find (changerName);
		player = FindObjectOfType<PlayerController> ();
		//Debug.Log ("This is the new Sprite " + newSprite);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("This is other.name " + other.name); 
		if (other.name == platformName) {
			//Debug.Log ("Inside the if statement"); 
			this.GetComponent<SpriteRenderer> ().sprite =
				newSprite.GetComponent<SpriteRenderer>().sprite;
			if (isFrozenType) {
				Physics2D.IgnoreCollision (player.GetComponent<BoxCollider2D> (), this.GetComponent<BoxCollider2D> (), true);
				//this.gameObject.layer = 8; //player layer, so won't be detected as platform
				//this.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
				//Debug.Log ("This is the new layer " + gameObject.layer); 
				//this.GetComponent<BoxCollider2D>().transform.position.x 

			}
		}


	}


}
