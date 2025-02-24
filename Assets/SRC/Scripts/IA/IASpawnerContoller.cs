using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IASpawnerContoller : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        FindPlayerReference();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) return;
        this.transform.position = playerTransform.position;
    }

    void FindPlayerReference()
    {
        var playerReference = GameObject.FindGameObjectWithTag("Player");

        if(playerReference == null) return;

        playerTransform = playerReference.transform;
    }
}
