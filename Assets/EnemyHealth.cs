using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using Unity.VisualScripting;

public class EnemyHealth : NetworkBehaviour
{
    public float MaxHealth = 100f;
    [SyncVar] public float Health = 100f;

    [SerializeField] private Image HealthBar;
 
    private void Update()
    {
        HealthBar.fillAmount = Health / MaxHealth;
    }


    [Command(requiresAuthority = false)]
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
