using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

    public Image EnemyHealthImage;
    //public Animation anim;
    //public Text ratioText;
    //public AudioClip hurt1;
    //public AudioClip hurt2;
    //public AudioClip death;
    //private AudioSource SoundSource;
    private float hitpoint1 = 150;
    private float maxHitpoint1 = 150;
    //private bool status;
    private bool dead;
    public Animator anim;
    //float Cooldown;
    //public GameObject enemy;

    private void Start()
    {
        //SoundSource = GetComponent<AudioSource>();
        UpdateHealthbar1();
        //Cooldown = 0;
        dead = false;
        //status = false;
        //Player = GameObject.Find("Player");
    }

    private void UpdateHealthbar1()
    {
        float ratio1 = hitpoint1 / maxHitpoint1;
        EnemyHealthImage.rectTransform.localScale = new Vector3(ratio1, 1, 1);
        if(hitpoint1 % 5 == 0 && hitpoint1>5)
            anim.SetTrigger("Hit");
        //ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    private void TakeDamage1(float damage1)
    {
        hitpoint1 -= damage1;
        
        /*if (status == false && Time.time > Cooldown && dead == false)
        {
            SoundSource.clip = hurt1;
            status = true;
            SoundSource.Play();
            Cooldown = Time.time + .75f;
        }
        else if (status == true && Time.time > Cooldown && dead == false)
        {
            SoundSource.clip = hurt2;
            status = false;
            SoundSource.Play();
            Cooldown = Time.time + .75f;
        }*/
        if (hitpoint1 <= 0)
        {
            hitpoint1 = 0;
            StartCoroutine(Die());
        }
        
        UpdateHealthbar1();
    }
    private IEnumerator Die()
    {
        if (dead == false)
        {
            dead = true;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //(Player.GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;
            //Destroy(Player.transform.Find("HylianShield").gameObject);
            Destroy(gameObject.GetComponent<BoxCollider>());
            anim.SetTrigger("Death");
            //SoundSource.clip = death;
            //SoundSource.Play();
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
            //Application.LoadLevel("menu");
        }

    }

}
