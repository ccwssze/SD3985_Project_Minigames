using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JumpingPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 9f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public static bool endGame;

    private PhotonView view;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        endGame = false;
    }

    void Update()
    {
        if (view.IsMine)
        {
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(horizontal, vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            if (horizontal > 0f)
            {
                player.velocity = new Vector2(horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else if (horizontal < 0f)
            {
                player.velocity = new Vector2(horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Timer.timerIsRunning)
        {
            endGame = true;
        }

        if (endGame)
        {
            player.velocity = new Vector2(0, 0);
        }
    }
}
