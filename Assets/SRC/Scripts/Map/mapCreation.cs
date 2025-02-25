using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mapCreation : MonoBehaviour
{
    [SerializeField] private GameObject[] planes;
    private Vector3 spawnPosition;
    [SerializeField] private string SpawnDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide");
        if (other.tag == "Player")
        {
            Debug.Log("Player Collide");
            if(SpawnDir == "right")
            {
               spawnPosition = new Vector3(29,-7,0);
            }
            if(SpawnDir == "left")
            {
                spawnPosition = new Vector3(-29,-7,0);
            }
            if(SpawnDir == "up")
            {
                spawnPosition = new Vector3(0,-7,29);
            }
            if(SpawnDir == "down")
            {
                spawnPosition = new Vector3(0,-7,-29);
            }
            var newPlane = Instantiate(planes[0], transform.position + spawnPosition, Quaternion.identity);
            GameObject parent = this.transform.parent.GameObject();
            Destroy(this.gameObject);
        } 

        
    }
}
