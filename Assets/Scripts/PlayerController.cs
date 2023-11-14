using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool onTheGround = false;
    private Animator animator;
    private Animation animation;
    private AudioSource playerAudio;
    private int amountOfJumps = 2;

    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        animation = GetComponent<Animation>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground")
        {
            onTheGround = true;
            amountOfJumps = 2;
            dirtParticle.Play();
        }
        if (collision.collider.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("Game over");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 0.8f);
            dirtParticle.Stop();    
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject.Find("Background").GetComponent<MoveLeft>().speed *= 2;
            if (GameObject.FindWithTag("Obstacle") != null)
            {
                GameObject.FindWithTag("Obstacle").GetComponent<MoveLeft>().speed *= 2;
                animator.speed *= 2;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GameObject.Find("Background").GetComponent<MoveLeft>().speed /= 2;
            if (GameObject.FindWithTag("Obstacle") != null)
            {
                GameObject.FindGameObjectWithTag("Obstacle").GetComponent<MoveLeft>().speed /= 2;
                animator.speed /= 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && amountOfJumps != 0 && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onTheGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.8f);
            animator.SetTrigger("Jump_trig");
            amountOfJumps -= 1;
        }
        if (transform.position.x != 2 && onTheGround)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(2,0,2), 3 * Time.deltaTime);
        }

    }
}
