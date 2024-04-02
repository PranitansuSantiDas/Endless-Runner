using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier;

    public bool isOnGround = true;

    public bool _gameOver;

    private Rigidbody _rBody;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        _rBody = GetComponent<Rigidbody>();

        //Physics.gravity = Physics.gravity * gravityModifier;
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }//Start

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            _rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            //Play Jump animation
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }//Update

    private void OnCollisionEnter(Collision target)
    {  
        if (target.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (target.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            _gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
    }//OnCollisionEnter

}//class
