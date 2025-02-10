using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class playerPigSpawner : MonoBehaviour
{
    private List<Transform> segments = new List<Transform>();

    void Start()
    {
        // Adiciona a cabeça da cobra como o primeiro segmento
        segments.Add(transform);
    }

    public void MoveSegments(Vector3 previousHeadPosition)
    {
        // Percorre os segmentos de trás para frente
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
            segments[i].transform.rotation = segments[i - 1].rotation;
        }

        // O primeiro segmento segue a posição anterior da cabeça
        if (segments.Count > 1)
        {
            segments[1].position = previousHeadPosition;
        }
    }

    public void AddSegment(GameObject segmentPrefab)
    {
        GameObject newSegment = Instantiate(segmentPrefab);
        newSegment.transform.position = segments[segments.Count - 1].position;
        segments.Add(newSegment.transform);
    }

    // protected GameObject porcoRef;
    // [SerializeField] protected GameObject porcoPref; 
    // [SerializeField] protected GameObject parentRef;


    // [SerializeField] protected playerSnakeMoviment snakeMovScript;


    // protected List<GameObject> porcoSeg;
    // Vector3 direc;
    // float grid;

    // public float moveDelay = 10.0f;a
    // private bool canMove = true;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     porcoSeg = new List<GameObject>();
    //     porcoSeg.Add(this.gameObject);
    //     //parentRef = GameObject.FindGameObjectWithTag("Player");   
    //     snakeMovScript = GetComponent<playerSnakeMoviment>();   
            
    // }

    // // Update is called once per frame
    // void Update()
    // {

    //     if (Input.GetMouseButtonDown(0))
    //    {
    //         Grow();
    //    }
        
    // }

    // void FixedUpdate()
    // {
    //     direc = snakeMovScript._dir;
    //     grid = snakeMovScript.gridSize;
    //     Debug.Log(direc);
    //     Debug.Log(canMove);

    //      for (int i = porcoSeg.Count - 1; i > 0; i-- )
    //          {
    //              porcoSeg[i].transform.position = porcoSeg[i - 1].transform.position * grid;
    //              porcoSeg[i].transform.rotation = porcoSeg[i - 1].transform.rotation;
                
    //          }

    // //    if(canMove)
    // //    {
            

    // //         for (int i = 0; i < porcoSeg.Count; i++ )
    // //         {
    // //             porcoSeg[i + 1].transform.position = porcoSeg[i].transform.position + direc;
    // //             porcoSeg[i + 1].transform.rotation = porcoSeg[i].transform.rotation;
    // //         }

    // //         StartCoroutine(Move());
    // //     }

    // //     if(canMove)
    // //     {
    // //         StartCoroutine(Move());
    // //     }

    // }

    // private IEnumerator Move()
    // {
    //    canMove = false;

    //     for (int i = porcoSeg.Count - 1; i > 0; i-- )
    //     {
    //         porcoSeg[i].transform.position = porcoSeg[i - 1].transform.position - (direc * 2);
    //         porcoSeg[i].transform.rotation = porcoSeg[i - 1].transform.rotation;
    //     }

    //     yield return new WaitForSeconds(0.25f);
    //     canMove = true;
    //  }

    //  void Grow()
    // {
    //     GameObject newPig = Instantiate(this.porcoPref);
    //     newPig.transform.parent = parentRef.transform;
    //     newPig.transform.position = porcoSeg[porcoSeg.Count - 1].transform.position - (direc * 2);

    //     porcoSeg.Add(newPig);
    // }
}
        
