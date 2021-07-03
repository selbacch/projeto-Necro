using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public Transform Target;
    public EnemyAttackArea AreaAtaque;
    public EnemyAggroArea AreaPerigo;
    public Animator anim;
    public float Speed;
    public float TargetDistance;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    private float timeDestroy;
    public NavMeshAgent nave;
    public bool IA;
    public bool isAttackingEnemy;
    public float Vida = 100;


    private bool isHuntingPlayer;
    private bool isAttackingPlayer;
    private Vector3 localInicial;

    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


      


        EnemyAggroArea.PlayerEntrouAggro += PlayerEntrouAggro;
        EnemyAggroArea.PlayerSaiuAggro += PlayerSaiuAggro;

        EnemyAttackArea.PlayerEntrouAttack += PlayerEntrouAttackArea;
        EnemyAttackArea.PlayerSaiuAttack += PlayerSaiuAttackArea;




    }

    void Update()
    {
       
       
            navhunt();

        if (Vida <= 0)
        {
            //anim.SetBool("death"true);
            Delete();
        }

        


    }




    void hunt()   // caça o inimigo
    {
        Vector3 direction = Target.transform.position - transform.position;

        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();


        if (distanceToTarget < TargetDistance)
        {
            direction = -direction;

        }
        anim.SetFloat("Horizontal", direction.x); // controla as animações
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("speed", direction.magnitude);

        if (distanceToTarget == TargetDistance)
        {
            if (direction.y > 0)
            {
                anim.SetInteger("Idle", 1);
            }
            if (direction.y < 0) { anim.SetInteger("Idle", -1); }

            if (direction.x > 0)
            {
                anim.SetInteger("Idle", 2);
            }
            if (direction.x < 0) { anim.SetInteger("Idle", -2); }
        }







        float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }


    IEnumerator Atacar()
    {
        for (; ; )
        {
            anim.SetTrigger("atack");
            

            yield return new WaitForSeconds(2);
        }
    }

    void navhunt()
    {
        nave.SetDestination(Target.transform.position);
        Vector3 direction = Target.transform.position - transform.position;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();


        anim.SetFloat("Horizontal", direction.x); // controla as animações
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("speed", direction.magnitude);


    }
    public void LevaDano(float dano)
    {
        Vida = Vida - dano;
    }

    void VoltarPosicaoInicial()
    {

        if (isHuntingPlayer || isAttackingPlayer)
            return;
        nave.SetDestination(this.localInicial - transform.position);
        Vector3 direction = this.localInicial - transform.position;

        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();
        float distanceWantsToMoveThisFrame = 5 * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);
        MoveCharacter(actualMovementThisFrame * direction);
    }


    void Atack()
    {
        if (Target.gameObject.tag == "Player")
        {
            Target.GetComponent<Health>().DamagePlayer(5);
        }
        if (Target.gameObject.tag == "sumon")
        {
            Debug.Log("-3");
            Target.GetComponent<Zombi>().TomaDano(5f);
        }
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }


    public void Delete() //destroi apos 10
    {
       
        Destroy(gameObject, timeDestroy);
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


}