using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Sword : MonoBehaviour {

	private Animator animator;
	private AudioSource SoundSource;
	private bool status;
	public AudioClip att1;
	public AudioClip att2;
	float Cooldown;
	public RazerHydraPlugin hydra;
	GameObject Player;

	void Start () {
		animator = GetComponent<Animator>();
		SoundSource = GetComponent<AudioSource>();
		status = false;
		Cooldown = 0;
		Player = GameObject.Find("Player");
		hydra = new RazerHydraPlugin();
		hydra.init();

	}
	
	// Update is called once per frame
	void Update () {

		hydra = Player.GetComponent<FirstPersonController>().hydra; //**hydra
		hydra.getNewestData(1);
		//if (Input.GetButtonDown ("Fire1") && Time.time > Cooldown) { //**PC
		if (hydra.data.trigger > 0.8 && Time.time > Cooldown) {
			Cooldown = Time.time + 1f;

			PerformAttack ();
			if (status == false) {
				SoundSource.clip = att1;
				status = true;
				SoundSource.Play ();
			} else {
				SoundSource.clip = att2;
				status = false;
				SoundSource.Play ();
			}
		}


	}

	public void PerformAttack(){
		animator.SetTrigger ("Base_Attack");
	}
}
