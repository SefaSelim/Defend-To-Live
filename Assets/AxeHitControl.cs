using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitControl : MonoBehaviour
{
    AxeThrow axeThrow;
    Collider2D Collider2D;

    private void Start()
    {
        axeThrow = GetComponent<AxeThrow>();
        Collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (axeThrow.isFlipping)
        {
            Collider2D.enabled = true;
        }
        else
        {
            Collider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
        }

    }
}
