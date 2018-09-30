using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

		bool atRight;
		public Transform startMarker;
		public Transform endMarker;
		public Transform tempPosition;
		public float speed = 1.0F;
		private float startTime;
		private float journeyLength;
		public PlayerController player;

		private Vector3 scale;


		void Start() {
			atRight = false;
			startTime = Time.time;
			journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
			player = FindObjectOfType<PlayerController> (); 
			scale = transform.localScale;
			tempPosition = startMarker;
		}

		void Update() {

			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);


			if (this.transform.position == endMarker.position) {
				atRight = true;
			}
			if (atRight) {
				tempPosition = startMarker;
				startMarker = endMarker;
				endMarker = tempPosition;
				//scale.x *= -1;
				transform.localScale = scale;
				startTime = Time.time;
				distCovered = 0;
				atRight = false;
			}
		}
	}


	
