using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreation : MonoBehaviour
{
    [SerializeField] private GameObject[] planes;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3(29,-7,0);
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
            var newPlane = Instantiate(planes[0], transform.position + spawnPosition, Quaternion.identity);
        } 

        
    }
}
