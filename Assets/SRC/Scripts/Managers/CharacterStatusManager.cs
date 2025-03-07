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
    private PlayerStatusHUD statusHUD;

    private void Start()
    {
        statusHUD = GetComponent<PlayerStatusHUD>();
    }

    public void InitStatus(Status pStatus)
    {
        status.Health = pStatus.Health;
        status.Armor = pStatus.Armor;
        status.MagicResist = pStatus.MagicResist;
        if(this.gameObject.tag == "Player")
        {
            statusHUD.UpdateHudLife(pStatus.Health);
        }
    }

    private void Update()   
    {
        // if(Input.GetKeyDown(KeyCode.T))
        // {
        //     TakeDamage(Random.Range(1,5));
        // }
        if(this.gameObject.tag == "Player")
        {
            statusHUD.UpdateHudLife(status.Health);
        }
    }
    public void TakeDamage(int amount)
    {
        status.Health -= amount;

        OnTakeDamage?.Invoke();

        //Anima Dano
        //Sangue
        //Num Dnao

        if(status.Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if(this.gameObject.tag == "Player")
        {
            statusHUD.OnDeath();
        }
        Destroy(this.gameObject);
    }
}
