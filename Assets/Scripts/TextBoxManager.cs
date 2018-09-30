using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFile;//textasset = block of text
	public string[] textLines;

	public int currentLine; 
	public int endAtLine; 

	//	public AndroControl player;
	public PlayerController player;
	public bool dialogueIsFinished;

	public bool isActive;

	public bool stopPlayerMovement; 


	public Button yourButton;


	// Use this for initialization
	void Start () {
		//Button btn = yourButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);

		//	player = FindObjectOfType<AndroControl> ();
		player = FindObjectOfType<PlayerController> ();
		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}

		//can break up dialogue with this code!
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1; 
		}


		if (isActive) {
			EnableTextBox ();
			dialogueIsFinished = false;
		} else {
			DisableTextBox ();
			dialogueIsFinished = true;
		}
	}

	void Update() {
		if (!isActive) {
			return;
		}
		theText.text = textLines[currentLine]; 
		//getting images
		/*if (theText.text.Contains ("Andromeda:")) {
			GameObject.Find ("HeadShot").GetComponent<Image> ().sprite =
				GameObject.Find ("AndromedaHead").GetComponent<SpriteRenderer> ().sprite;
		} else if (theText.text.Contains ("Ms. Estella:")) {
			GameObject.Find ("HeadShot").GetComponent<Image> ().sprite =
				GameObject.Find ("MsEstellaHead").GetComponent<SpriteRenderer> ().sprite;
		} else if (theText.text.Contains ("Aarathi:")) {
			GameObject.Find ("HeadShot").GetComponent<Image> ().sprite =
				GameObject.Find ("AarathiHead").GetComponent<SpriteRenderer> ().sprite;
		} else if(theText.text.Contains ("Snow Woman:")){
			GameObject.Find ("HeadShot").GetComponent<Image> ().sprite =
				GameObject.Find ("SnowWomanHead").GetComponent<SpriteRenderer> ().sprite;
		} else if(theText.text.Contains ("Unknown Girl:")){
			GameObject.Find ("HeadShot").GetComponent<Image> ().sprite =
				GameObject.Find ("Ballerinahead").GetComponent<SpriteRenderer> ().sprite;
		}*/





		if (Input.GetKeyDown (KeyCode.Return)) {
			currentLine++;
		}

		if (currentLine > endAtLine) {
			DisableTextBox ();
			//GameObject.Find ("HeadShot").GetComponent<Image> ().sprite = 
			//GameObject.Find ("AndromedaHead").GetComponent<SpriteRenderer> ().sprite;//was null
		}

	}


	public void EnableTextBox(){
		textBox.SetActive (true);
		isActive = true;
		//	stopPlayerMovement = true;
		if (stopPlayerMovement) {
			player.CanMove = false;
		}
	}

	public void DisableTextBox(){
		textBox.SetActive (false);
		isActive = false;
		//	stopPlayerMovement = false;
		player.CanMove = true;
	}

	public void ReloadScript(TextAsset theText){
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));

		}

	}


	public void MouseDownPressed(){
		//gameObject.GetComponent<Button>().interactable = false;
		currentLine++;
	}




}
