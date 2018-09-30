using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	public string sceneName;

	public void ButtonClicked(){
		SceneManager.LoadScene (sceneName);
	}
}
