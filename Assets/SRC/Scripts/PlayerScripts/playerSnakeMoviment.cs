using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerSnakeMoviment : MonoBehaviour
{
    private NavMeshAgent nav;
    public Vector3 _dir;
    private Vector3 _nextPos;
    private Rigidbody rb;
    public float gridSize = 1.0f; // Tamanho da grade de movimento
    public float moveSpeed = 5f;
    public float moveDelay = 0.5f; // Tempo entre movimentos
    private bool canMove = true;

    //private float moveTimer = 1f;

    [Header("Segments Controller")]
    public playerPigSpawner snakeSegments;
    
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        snakeSegments = GetComponent<playerPigSpawner>();
        rb = GetComponent<Rigidbody>();
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
    }

    void FixedUpdate()
    {
        // moveTimer += Time.deltaTime;
        // if (moveTimer >= 1f / moveSpeed)
        // {
        //     rbMove();
        //     moveTimer = 0f;
        // }

        if (canMove)
        {
            StartCoroutine(Move());
        }
    }

    void rbMove()
    {
        // Guarda a posição anterior da cabeça antes de mover
        Vector3 previousPosition = rb.position;

        // Calcula a nova posição
        _nextPos = previousPosition + _dir * gridSize;

        rb.MovePosition(_nextPos);

        snakeSegments.MoveSegments(previousPosition);

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

        // Move os segmentos chamando o script SnakeSegments
        snakeSegments.MoveSegments(previousPosition);
        
        // Movimento Suave
        //nav.SetDestination(_nextPos);

        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }
}
