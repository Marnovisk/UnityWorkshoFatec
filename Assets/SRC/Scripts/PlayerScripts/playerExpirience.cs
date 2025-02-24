using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerExpirience : MonoBehaviour
{
    public playerWeapons WeaponsScript;
    public int NeededExpirience;
    public int currentExpirience;
    [SerializeField] private GameObject _upgradeScreen;

    public void Awake()
    {
        WeaponsScript = GetComponent<playerWeapons>();
    }

    public void LevelUp()
    {
        currentExpirience = 0;
        NeededExpirience += 10;

        WeaponsScript.AddWeapon();
    }

    public void IncreaseXp(int amount)
    {
        currentExpirience += amount;

        if(currentExpirience >= NeededExpirience)
        {
            _upgradeScreen.SetActive(true);
        }
    }
}
