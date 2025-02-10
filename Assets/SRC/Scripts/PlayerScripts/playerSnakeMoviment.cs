using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerSnakeMoviment : MonoBehaviour
{
    private NavMeshAgent nav;
    public Vector3 _dir;
    private Vector3 _nextPos;
    public float gridSize = 1.0f; // Tamanho da grade de movimento
    public float moveDelay = 0.5f; // Tempo entre movimentos
    private bool canMove = true;

    [Header("Segments Controller")]
    public playerPigSpawner snakeSegments;
    public GameObject segmentPrefab;
    
    private int caralho;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        snakeSegments = GetComponent<playerPigSpawner>();
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && _dir != Vector3.back)
        {
            _dir = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _dir != Vector3.forward)
        {
            _dir = Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _dir != Vector3.right)
        {
            _dir = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _dir != Vector3.left)
        {
            _dir = Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            snakeSegments.AddSegment(segmentPrefab);
            caralho += 1;
        }
    }

    void FixedUpdate()
    {
       if (canMove)
        {
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        canMove = false;

        // Guarda a posição anterior da cabeça antes de mover
        Vector3 previousPosition = transform.position;

        // Calcula a nova posição
        _nextPos = previousPosition + _dir * gridSize;

        // Rotaciona a cabeça para olhar na direção do movimento
        transform.rotation = Quaternion.LookRotation(_dir, Vector3.up);

        // Move a cabeça
        nav.Warp(_nextPos);

        if(caralho > 0)
        {
        // Move os segmentos chamando o script SnakeSegments
        snakeSegments.MoveSegments(previousPosition);
        }
        // Movimento Suave
        //nav.SetDestination(_nextPos);

        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }
}
