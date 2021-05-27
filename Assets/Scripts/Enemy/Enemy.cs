using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public Transform Target;
    public EnemyAttackArea areaAtaque;
    public EnemyAggroArea areaPerigo;

    public Int32 vida;
    public float resfriamento;
    public Int32 raioAtaque;
    public Int32 raioPerigo;
    public Int32 velocidade = 1;

    private float TargetDistance;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    private Vector3 localInicial;
    private bool isHuntingPlayer;
    private bool isAttackingPlayer;
    // Start is called before the first frame update
    void Start()
    {

        TargetDistance = 0;
        EnemyAggroArea.PlayerEntrouAggro += PlayerEntrouAggro;
        EnemyAggroArea.PlayerSaiuAggro += PlayerSaiuAggro;

        EnemyAttackArea.PlayerEntrouAttack += PlayerEntrouAttackArea;
        EnemyAttackArea.PlayerSaiuAttack += PlayerSaiuAttackArea;

        isHuntingPlayer = false;
        isAttackingPlayer = false;
        localInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Hunt();
        VoltarPosicaoInicial();
    }


    void Hunt()
    {
        if (!isHuntingPlayer || isAttackingPlayer)
            return;
        Vector3 direction = Target.position - transform.position;

        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();

        // Mas se ja estiver perto demais, na verdade quero fugir.
        // Inverte a direção anterior.
        //if (distanceToTarget < TargetDistance)
        //{
        //    direction = -direction;

        //}

        ////    anim.SetFloat("Horizontal", direction.x); // controla as animações
        // //   anim.SetFloat("Vertical", direction.y);
        // //   anim.SetFloat("speed", direction.magnitude);

        //    if (distanceToTarget == TargetDistance)
        //    {
        //        if (direction.y > 0)
        //        {
        //            anim.SetInteger("Idle", 1);
        //        }
        //        if (direction.y < 0) { anim.SetInteger("Idle", -1); }

        //        if (direction.x > 0)
        //        {
        //            anim.SetInteger("Idle", 2);
        //        }
        //        if (direction.x < 0) { anim.SetInteger("Idle", -2); }
        //    }

        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = velocidade * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);
        MoveCharacter(actualMovementThisFrame * direction);
    }

    void VoltarPosicaoInicial()
    {

        if (isHuntingPlayer || isAttackingPlayer)
            return;
        Vector3 direction = this.localInicial - transform.position;

        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();
        float distanceWantsToMoveThisFrame = velocidade * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);
        MoveCharacter(actualMovementThisFrame * direction);
    }


    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    void PlayerEntrouAggro()
    {
        isHuntingPlayer = true;
    }
    void PlayerSaiuAggro()
    {
        isHuntingPlayer = false;
    }

    void PlayerEntrouAttackArea()
    {
        isAttackingPlayer = true;
    }

    void PlayerSaiuAttackArea()
    {
        isAttackingPlayer = false;
    }

}
