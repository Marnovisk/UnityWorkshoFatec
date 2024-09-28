using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("MainData")]
    [SerializeField] private EnemyScriptable brain;

    [Header("MainData")]
    [SerializeField] private Transform playerTransform;

    [Header("TransformData")]
    [SerializeField] private Transform GFXTransform;


    [Header("Scripts References")]
    private IAStates IAStatesScript;
    private IAMovement IAMovimentScript;
    private IAKombat IAKombatScript;

    [Header("References Check")]
    [SerializeField] private bool referencesOK;
    
    private void Start()
    {
              
    }

    public void Init(EnemyScriptable pBrain)
    {
        referencesOK = false;

        IAStatesScript = GetComponent<IAStates>();
        IAMovimentScript = GetComponent<IAMovement>();
        IAKombatScript = GetComponent<IAKombat>();

        brain = pBrain;
        IAKombatScript.Init(brain);

        InstantiateGraphics(); 
        FindPlayerReference();

        referencesOK = true;
    }

    private void Update()
    {
        if (referencesOK == false) return;
        if(playerTransform == null) return;

        if(IAStatesScript.States == IAStateType.CHASING)
        {
            ChaseBehavior();
            return;
        }

        if(IAStatesScript.States == IAStateType.ATTACKING)
        {
            AttackBehavior();
            return;
        }
    }

    void ChaseBehavior()
    {
        var sucess = IAMovimentScript.Chase(playerTransform);

        if(sucess == false)
        {
            IAStatesScript.ChangeToState(IAStateType.ATTACKING);
        }

    }

    void AttackBehavior()
    {
        var sucess = IAKombatScript.checkAndAttack(playerTransform);

        if(sucess == false)
        {
            IAStatesScript.ChangeToState(IAStateType.CHASING);
        }
    }

    void InstantiateGraphics()
    {
        Instantiate(brain.GFX, GFXTransform); 
    }

    void FindPlayerReference()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
