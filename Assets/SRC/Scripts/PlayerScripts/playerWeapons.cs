using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class playerWeapons : MonoBehaviour
{
   public  List <WeaponScriptable> Weapons;
   public WeaponScriptable[] AllWeapons;
   public LayerMask EnemiesLayer;

   public void AddWeapon()
   {
        Weapons.Add(AllWeapons[Random.Range(0, AllWeapons.Length)]);
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
       InvokeRepeating ("UsePlayerPositionWeapon", 0f, 15f);
       InvokeRepeating ("UseContinousSingleWeapon", 0f, 1f);
       InvokeRepeating ("UseContinousSingleWeapon", 0f, 15f);
   }

   public void UseTargetWeapon()
   {
        if (Weapons.Count <= 0) return;

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
            projectile.GetComponent<ITargetWeapon>().Init(closestTarget.transform);

        }
   }

   public void UsePlayerPositionWeapon()
   {
        if (Weapons.Count <= 0) return;

        foreach(WeaponScriptable weapon in Weapons)
        {
            if (weapon.type != WeaponType.PlayerPosition) continue;

            var projectile = Instantiate(weapon.proj, transform.position, Quaternion.identity);
            projectile.GetComponent<ITargetWeapon>().Init(this.transform);

        }
   }

   public void UseContinousSingleWeapon()
   {
        if (Weapons.Count <= 0) return;

        foreach(WeaponScriptable weapon in Weapons)
        {
            if (weapon.type != WeaponType.ConstinuousSingle) continue;

            var projectile = Instantiate(weapon.proj, transform.position, Quaternion.LookRotation(this.transform.forward, this.transform.up));
            projectile.GetComponent<ITargetWeapon>().Init(this.transform);

        }
   }

   public void UseContinousConstantWeapon()
   {
        if (Weapons.Count <= 0) return;

        foreach(WeaponScriptable weapon in Weapons)
        {
            if (weapon.type != WeaponType.ContinuousConstant) continue;

            var projectile = Instantiate(weapon.proj, transform.position, Quaternion.LookRotation(this.transform.forward, this.transform.up));
            projectile.GetComponent<ITargetWeapon>().Init(this.transform);

        }
   }

}
