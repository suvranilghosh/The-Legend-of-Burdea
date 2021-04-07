using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour {

    public Image CurrentHealth;
    public Text ratioText;
	public AudioClip hurt1;
	public AudioClip hurt2;
	public AudioClip death;
	private AudioSource SoundSource;
    private float hitpoint = 150;
    private float maxHitpoint = 150;
	private bool status;
	private bool dead;
	float Cooldown;
	GameObject Player;

    private void Start()
    {
		SoundSource = GetComponent<AudioSource>();
        UpdateHealthbar();
		Cooldown = 0;
		dead = false;
		status = false;
		Player = GameObject.Find ("Player");
    }

    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        CurrentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;
		if (status == false && Time.time > Cooldown && dead == false) {
			SoundSource.clip = hurt1;
			status = true;
			SoundSource.Play ();
			Cooldown = Time.time + .75f;
		} else if (status == true && Time.time > Cooldown && dead == false) {
			SoundSource.clip = hurt2 ;
			status = false;
			SoundSource.Play ();
			Cooldown = Time.time + .75f;
		}
        if (hitpoint <= 0)
        {
			
            hitpoint = 0;
			StartCoroutine(Die ());
        }
        UpdateHealthbar();
    }
	private IEnumerator Die()
	{
		if (dead == false) {
			dead = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			(Player.GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;

			Destroy(Player.transform.Find ("Master_Sword").gameObject);
			Destroy(Player.transform.Find ("HylianShield").gameObject);

			SoundSource.clip = death;
			SoundSource.Play ();
			yield return new WaitForSeconds (2);
			Application.LoadLevel ("menu");
		}
	
	}

}
