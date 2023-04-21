using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool gameOver;
    public bool isOnGround = true;
    private Animator playerAnim;
    public ParticleSystem magicParticle;
    public AudioClip crashSound;
    public AudioClip collectSound;
    private AudioSource playerAudio;
    public bool pointCollected;
    public GameOverScreen GameOverScreen;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

    }

    // Fly with space, stop jumping when dead
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
        }
    }
    // Point collected sound and particle effect
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("Flower"))
        {
            pointCollected = true;
            magicParticle.Play();
            playerAudio.PlayOneShot(collectSound, 1.0f);
            Debug.Log("You collected a point!");
            ScoreManager.instance.AddPoint();
        }
    }

    // Game over sound and animation
    public void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
        gameOver = true;
        Debug.Log("Game Over!");
            playerAnim.SetTrigger("death");
            playerAudio.PlayOneShot(crashSound, 1.0f);
            GameOverScreen.Setup(score);
        }
    }

}
