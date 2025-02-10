using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMoviment : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;
    private NavMeshAgent nav;
    
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();        
    }

    private void PlayerInput()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            ManageMovement();
        }

    }

    private void ManageMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    nav.SetDestination(hit.point);
                }
                
            }   
    }
}
