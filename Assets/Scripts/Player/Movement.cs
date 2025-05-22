using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Movement : NetworkBehaviour
{
    public float speed = 5f;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (isLocalPlayer)
        {
            gameObject.name = "LOCALPLAYER";
        }
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveX = -moveX;
        }
        else if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (moveX != 0 || moveY != 0)
            {
            animator.SetBool("Walking", true);
        }
        else 
        {
            animator.SetBool("Walking", false);

        }

        Vector3 move = transform.right * moveX + transform.up * moveY;
        transform.position += move * speed * Time.deltaTime;

    }

    [Command]
    private void flipCMD(bool flipX)
    {
        
    }
    [ClientRpc]
    private void flipRPC(bool flipX)
    {
        
    }
}

