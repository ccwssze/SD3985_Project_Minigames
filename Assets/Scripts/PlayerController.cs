using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    private bool endGame;

    PhotonView view;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        endGame = false;
    }

    void Update()
    {
        if (view.IsMine)
        {
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


            if (Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }
        }
    }
    void FixedUpdate()
    {
        if (!Timer.timerIsRunning)
        {
            endGame = true;
        }

        if (!endGame)
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        } 
    }
}
