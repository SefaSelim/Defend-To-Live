using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AxeThrow : NetworkBehaviour
{
    [SerializeField] AxeLerp axeLerp;
    [SerializeField] Transform playerTransform;

    public float throwForce = 10f;
    public float rotationSpeed = 10f;

    private Rigidbody2D _rb2D;
    Vector2 dir;

    
    public bool isFlipping = false;
    bool afterThrow = false;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Space) && !isFlipping)
        {
            dir = Input.GetAxis("Horizontal") < 0 ? new Vector2(-1, 0) : new Vector2(1, 0);
            throwAxe(dir);
            isFlipping = true;
            afterThrow = true;
        }

        if (isFlipping)
        {
            if (dir.x < 0)
            transform.Rotate(0, 0, rotationSpeed* 10 * Time.deltaTime);
            else
            transform.Rotate(0, 0, -rotationSpeed * 10 *Time.deltaTime);
        }

        if (afterThrow)
        {
            _rb2D.AddForce((playerTransform.position - transform.position)/100, ForceMode2D.Impulse);

            if (Mathf.Abs(playerTransform.position.x - transform.position.x) < 0.25f)
            {
                PullAxeBack();
                afterThrow = false;
            }
        }


    }


    private void throwAxe(Vector2 dir)
    {
        axeLerp.throwing = true;
        _rb2D.AddForce(dir * throwForce, ForceMode2D.Impulse);

    }

    private void PullAxeBack()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rb2D.velocity = Vector2.zero;
        axeLerp.throwing = false;
        isFlipping = false;
    }


}
