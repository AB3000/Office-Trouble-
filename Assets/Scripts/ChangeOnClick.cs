using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnClick : MonoBehaviour {

	public string secondSprite;
	public float yOffset, xOffset, yScale, xScale;
	public bool isOpen; 
	public bool hasObject;
	public string objectName; 
	private GameObject obj; //= GameObject.Find(objectName);
	private Rigidbody2D objectRigid;


	void Start(){
		isOpen = false;
		//obj = GameObject.Find (objectName);
		if (hasObject){
			/*obj =*/ //obj = GameObject.Find (objectName).gameObject.SetActive (false);
			obj = GameObject.Find(objectName);
			obj.SetActive (false);
		}
		//obj.gameObject.SetActive(false);
		//obj.SetActive (false);
	}

	void OnMouseDown(){

		//Debug.Log ("Is being clicked");

		if (isOpen == true) {
			return; 

		}
		this.GetComponent<SpriteRenderer> ().sprite = 
		GameObject.Find (secondSprite).GetComponent<SpriteRenderer> ().sprite;

		this.transform.position = new Vector3 (transform.position.x + xOffset, transform.position.y
		+ yOffset, transform.position.z);

		this.transform.localScale = new Vector3 (this.transform.localScale.x * xScale, 
			this.transform.localScale.y * yScale,
			this.transform.localScale.z);

		if (hasObject) {
			//obj.SetActive (true);
			//Debug.Log("This is the object's name: " + objectName);
			//GameObject.Find (objectName).gameObject.SetActive (true);
			obj.SetActive (true);
		}

		isOpen = true;

	}


}

