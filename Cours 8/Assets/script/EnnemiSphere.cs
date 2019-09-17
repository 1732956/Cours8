using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSphere : Ennemi {
    GameObject player;
    public float speed = 5;
    Rigidbody rgb;
    AudioSource audioSource;
    public AudioMusic audioMusic;
    public GameObject particleSystemDeath;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rgb = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        FolowPLayer();
    }

    private void FolowPLayer()
    {
        rgb.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position,speed * Time.deltaTime));
    }

    public override void Die()
    {
        audioSource.PlayOneShot(audioMusic.soundToPlay);
        Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
        Instantiate(gameObject, gameObject.transform.position + new Vector3(5,0,0), Quaternion.identity);
        Instantiate(particleSystemDeath, gameObject.transform.position - new Vector3(5, 0, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
