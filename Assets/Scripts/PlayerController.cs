using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float maxS = 11f;
	bool isRight = true;
	Animator a;

	bool isOnGround = false;
	public Transform GroundCheck;
	float groundRadius = 0.14f;
	public float jForce = 400f; 
	public LayerMask wiGround;
	public bool CanMove;
	private int number;
	int[] objects = {4, 6, 7 , 4, 3};
	int objectIndex;

	void Start () {
		a = GetComponent <Animator> (); 
		number = 0;
		objectIndex = 0;

	}

	void Update(){
		if(isOnGround && Input.GetKeyDown(KeyCode.Space)){
			a.SetBool ("Ground", false); 
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jForce)); 
		}
		
	}
	//mainly for jumping
	void FixedUpdate(){
		isOnGround = Physics2D.OverlapCircle (GroundCheck.position, groundRadius, wiGround);
		a.SetBool ("Ground", isOnGround); 
		// velocity = 0 then switch to downward animation?
		a.SetFloat ("verticalSpeed", GetComponent<Rigidbody2D> ().velocity.y); 
		//Debug.Log (a.GetFloat ("verticalSpeed") + " is the current vertical speed"); 
		float move = Input.GetAxis ("Horizontal"); 
		a.SetFloat ("speed", Mathf.Abs(move));
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxS,
			GetComponent<Rigidbody2D> ().velocity.y); 

		if (move > 0 && !isRight) {
			Flip ();
		} else {
			if (move < 0 && isRight) {
				Flip ();
			}
		}

	}

	void Flip(){
		isRight = !isRight; 
		Vector3 scale = transform.localScale; 
		scale.x *= -1; 
		transform.localScale = scale; 
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "object") {
			GameObject holder = GameObject.Find ("Object" + number);
			holder.GetComponent<SpriteRenderer>().sprite = 
				other.gameObject.GetComponent<SpriteRenderer> ().sprite;
			holder.transform.localScale = new Vector3 (other.transform.localScale.x * 5,
				other.transform.localScale.y * 5, other.transform.localScale.z); 
			
			//other.gameObject.GetComponent<SpriteRenderer>().sprite = 
			Destroy (other.gameObject); //UNCOMMENT WHEN FINISH DESTROY
			Debug.Log("This is number " + number);

			/*other.transform.position = new Vector3 (GameObject.Find ("Object" + number).transform.position.x,
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
			//objectCount++;

			Debug.Log ("This is number: " + number); */
			if(objects[objectIndex] == number){
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
				objectIndex++;
				number = 0;
			}

		}
	}



}

















