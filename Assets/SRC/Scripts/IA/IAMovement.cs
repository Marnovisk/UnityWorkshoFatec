using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class IAMovement : MonoBehaviour
{
    private NavMeshAgent nav;

    [Header("Enemy Info")]
    public float AttackRange;
    public float AttackSpeed;
    public float currentAttackCooldown;
    public int[] AttackDamage;
    public bool canAttack;

    [Header("Player Info")]
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = AttackRange;
    }

    // Update is called once per frame
    void Update()
    {  
        if(player == null) return;      
        Chase();
        
        if(Vector3.Distance(this.transform.position, player.transform.position) <= AttackRange){
            
             if(canAttack)
            {
                Attack();
            } else
            {
                currentAttackCooldown -= Time.deltaTime;
                if (currentAttackCooldown <= 0)
                {
                    canAttack = true;
                    currentAttackCooldown = AttackSpeed;
                }
            }

        } 

       
        
    }

    void Attack()
    {
        canAttack = false;
        player.GetComponent<IDamagable>().TakeDamage(Random.Range(AttackDamage[0],AttackDamage[1]));        
    }

    void Chase()
    {
        nav.SetDestination(player.position);
    }

    
}
