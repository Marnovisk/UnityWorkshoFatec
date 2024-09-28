using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyData", order = 0)]
public class EnemyScriptable : ScriptableObject
{
   [Header("Data")]
   public Status Status;

   [Header("Kombat Data")]
    public float AttackRange;
    public float AttackSpeed;
    public int[] AttackDamage;
    

   [Header("Data")]
   public GameObject GFX;



}
