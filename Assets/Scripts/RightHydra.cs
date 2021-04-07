using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHydra : MonoBehaviour {

	public RazerHydraPlugin hydra;
	CharacterController CharController;

	void Start () {
		hydra = new RazerHydraPlugin();
		hydra.init();
		CharController = this.GetComponent<CharacterController>();

	}

	void Update () {
		
		hydra.getNewestData(1);
		//this.transform.rotation = Quaternion.Euler(-hydra.data.position.y,hydra.data.position.x,0);
		CharController.SimpleMove(Camera.main.transform.forward * hydra.data.joystick_y*2);
		CharController.SimpleMove(Camera.main.transform.right * hydra.data.joystick_x*2);

	}
}
