using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButtons : MonoBehaviour {


	public void startGame () {
		Application.LoadLevel ("forest");
		//GameObject.Find ("Canvas").active = false;
	}


	public void closeGame () {
		Application.Quit();
	}
}
