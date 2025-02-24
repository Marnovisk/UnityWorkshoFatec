using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private GameObject _upgradeScreen;
    // Start is called before the first frame update
    void Start()
    {
        _upgradeScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectUpgrade()
    {
        _upgradeScreen.SetActive(false);
    }
}
