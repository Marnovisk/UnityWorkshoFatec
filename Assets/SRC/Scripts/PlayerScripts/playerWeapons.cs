using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class playerWeapons : MonoBehaviour
{
   public WeaponScriptable[] Weapons;
   public LayerMask EnemiesLayer;

   public void AddWeapon(WeaponScriptable weapon)
   {

   }

   public void UpgradeWeapon(WeaponScriptable weapon)
   {

   }

   public void UseWeapon(WeaponScriptable weapon)
   {

   }

   public void Start()
   {
       InvokeRepeating ("UseTargetWeapon", 0f, 1f);
   }

   public void UseTargetWeapon()
   {
        if (Weapons.Length <= 0) return;

        foreach(WeaponScriptable weapon in Weapons)
        {
            if (weapon.type != WeaponType.NeedTarget) continue;

            var nearbyEnemies = Physics.OverlapSphere(transform.position, weapon.Range, EnemiesLayer);
            
            if(nearbyEnemies.Length <= 0) continue;

            var closestTarget = nearbyEnemies[0];
            var closestDistance = 999999f;

            foreach (Collider enemy in nearbyEnemies)
            {
                var distance = Vector3.Distance(transform.position, enemy.transform.position);

                if(distance < closestDistance)
                {
                    closestTarget = enemy;
                    closestDistance = distance;
                }
            }

            var projectile = Instantiate(weapon.proj, transform.position, Quaternion.identity);
            projectile.GetComponent<TargetProjectile>().Init(closestTarget.transform);

        }
   }

}
