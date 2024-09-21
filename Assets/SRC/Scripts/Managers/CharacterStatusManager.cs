using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStatusManager : MonoBehaviour, IDamagable
{
    public Status status;
    public event Action OnTakeDamage;

    private void Start()
    {
        status.Init();
    }

    private void Update()   
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(Random.Range(1,5));
        }
    }
    public void TakeDamage(int amount)
    {
        Debug.Log("Tomando " + amount + " de dano");

        status.Health -= amount;

        OnTakeDamage?.Invoke();

        if(status.Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
