using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Atacavel
{
    public Animator Anim;
    public Player Target;
    public EnemyAttackArea AreaAtaque;
    public EnemyAggroArea AreaPerigo;

    public Int32 Vida = 100;
    public float Resfriamento = 2;
    //public Int32 RaioAtaque = 2.5;
    //public Int32 RaioPerigo = 5;
    public Int32 Velocidade = 1;
    public Int32 Dano = 15;



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
        Vector3 direction = Target.transform.position - transform.position;

        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();


        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = Velocidade * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);
        MoveCharacter(actualMovementThisFrame * direction);
    }

    IEnumerator Atacar()
    {
        for (; ; )
        {
            Target.SofrerDano(this);
            Debug.Log("ATAQUEEEEEEI");
            yield return new WaitForSeconds(2);
        }
    }

    void VoltarPosicaoInicial()
    {

        if (isHuntingPlayer || isAttackingPlayer)
            return;
        Vector3 direction = this.localInicial - transform.position;

        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();
        float distanceWantsToMoveThisFrame = Velocidade * Time.deltaTime;
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
        StartCoroutine("Atacar");
    }

    void PlayerSaiuAttackArea()
    {
        isAttackingPlayer = false;
        StopCoroutine("Atacar");
    }

    public void CausarDano(Atacavel atacado)
    {
        throw new NotImplementedException();
    }

    public void SofrerDano(Atacavel atacante)
    {
        Vida -= atacante.DanoCausado();
        if (Vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int DanoCausado()
    {
        return this.Dano;
    }
}
