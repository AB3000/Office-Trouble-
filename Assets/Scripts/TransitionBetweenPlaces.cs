using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenPlaces : MonoBehaviour {

	public GameObject goToPlace; 
	public PlayerController player;
	public bool isDoor;
	public float xOffset, yOffset;
	public bool isActivated = false;

	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isActivated) {
			if (isDoor && Input.GetKeyDown(KeyCode.Return)) {
				player.transform.position = new Vector3 (goToPlace.transform.position.x + xOffset,
					goToPlace.transform.position.y + yOffset, goToPlace.transform.position.z); 
			
			} else if (!isDoor){
				player.transform.position = new Vector3 (goToPlace.transform.position.x + xOffset,
					goToPlace.transform.position.y + yOffset, goToPlace.transform.position.z); 
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			isActivated = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			isActivated = false;
		}
	}
}
