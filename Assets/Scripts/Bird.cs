﻿using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200.0f;

    public AudioClip flySFX;
    public AudioClip dieSFX; 

    private bool isDead  = false;

    private AudioSource audioSource;
    private Animator anim;                  
    private Rigidbody2D rb2d;               

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));

                audioSource.PlayOneShot(flySFX);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.BirdDied();

        audioSource.PlayOneShot(dieSFX);
    }
}