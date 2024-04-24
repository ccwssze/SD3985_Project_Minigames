using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        PhotonView view;

        private void Start()
        {
            animator = GetComponent<Animator>();
            view = GetComponent<PhotonView>();
        }


        private void Update()
        {
            if (view.IsMine)
            {
                Vector2 dir = Vector2.zero;
                if (Input.GetKey(KeyCode.A))
                {
                    dir.x = -1;
                    animator.SetInteger("Direction", 3);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    dir.y = 1;
                    animator.SetInteger("Direction", 1);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    dir.y = -1;
                    animator.SetInteger("Direction", 0);
                }

                dir.Normalize();
                animator.SetBool("IsMoving", dir.magnitude > 0);

                GetComponent<Rigidbody2D>().velocity = speed * dir;
            }
        }
    }
}
