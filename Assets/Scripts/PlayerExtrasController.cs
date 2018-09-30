using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtrasController : MonoBehaviour {

	public float maxS = 11f;
	bool isRight = true;
	Animator a;

	bool isOnGround = false;
	//public Transform GroundCheck;
	public PlayerController player;
	float groundRadius = 0.14f;
	public float jForce = 400f; 
	public LayerMask wiGround; 
	public float xOffset, yOffset;
	bool changeMade = false;
	//public bool hasOffset;

	void Start () {
		a = GetComponent <Animator> (); 
		player = FindObjectOfType <PlayerController> (); 
		//Debug.Log ("The player is " + player.name); 
	}

	void Update(){
		if(isOnGround && Input.GetKeyDown(KeyCode.Space)){
			a.SetBool ("Ground", false); 
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jForce)); 
		}

		//hair up = vertical speed > 0 && ground is false
		/*if (!isOnGround && a.GetFloat ("verticalSpeed") > 0 && changeMade == false) {
			this.transform.position = new Vector3 (this.transform.position.x + xOffset,
				this.transform.position.y + yOffset,
				this.transform.position.z); 
			//changeMade = true;
		}*/
			
	}
	//mainly for jumping
	void FixedUpdate(){

		//isOnGround = player.GetComponent<Animator>().GetBool("Ground");
		//Debug.Log ("The player is on ground? " + player.GetComponent<Animator> ().GetBool ("Ground"));
		a.SetBool ("Ground", isOnGround); 
		// velocity = 0 then switch to downward animation?
		a.SetFloat ("verticalSpeed", player.GetComponent<Rigidbody2D> ().velocity.y); 
		//Debug.Log (a.GetFloat ("verticalSpeed") + " is the current vertical speed"); 
		float move = Input.GetAxis ("Horizontal"); 
		a.SetFloat ("speed", Mathf.Abs(move));
		player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxS,
			player.GetComponent<Rigidbody2D> ().velocity.y); 

		//if(a.GetComponent<Animator>().get

		/*if (move > 0 && !isRight) {
			Debug.Log ("Has been flipped first");
			Flip ();
		} else {
			if (move < 0 && isRight) {
				Flip ();
				Debug.Log ("Has been flipped second");
			}
		}*/

		/*if (hasOffset) {
			this.transform.position = new Vector3 (this.transform.position.x + xOffset,
				this.transform.position.y + yOffset,
				this.transform.position.z); 
		}*/

	}

	void Flip(){
		isRight = !isRight; 
		Vector3 scale = transform.localScale; 
		scale.x *= -1; 
		transform.localScale = scale; 
		this.transform.position = new Vector3 (this.transform.position.x + xOffset,
			this.transform.position.y + yOffset,
			this.transform.position.z); 
	}

	



}




/*void OnTriggerEnter2D(Collider2D other){
	if (other.tag == "object") {

		other.transform.position = new Vector3 (GameObject.Find ("Object" + number).transform.position.x,
			GameObject.Find ("Object" + number).transform.position.y,
			GameObject.Find ("Object" + number).transform.position.z);

		other.transform.SetParent (GameObject.Find ("Object" + number).transform);

		//other.transform.localScale = new Vector3(10f,10f,10f);
		other.transform.localScale = new Vector3 (other.transform.localScale.x / 6, 
			other.transform.localScale.y / 6,
			other.transform.localScale.z / 6);

		if (other.GetComponent<Rigidbody2D> () != null) {
			other.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			other.GetComponent<BoxCollider2D> ().enabled = false;
		}

		number++;
		objectCount++;

		Debug.Log ("This is number: " + number); 
	}*/












