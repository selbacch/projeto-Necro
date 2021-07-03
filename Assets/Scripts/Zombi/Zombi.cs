using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombi : MonoBehaviour
{

     public Animator anim;
    public float Speed;
    public Transform Target;
    public float TargetDistance ;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    private float timeDestroy= 50;
    public NavMeshAgent nave;
    public bool IA;
    public zombiagroarea AreaAtaque;
    public ZombiatackArea AreaPerigo;
    public bool isAttackingEnemy;
    public float Vida = 100;
    public float dano;
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
       

        if (Target == null)
           Target = GameObject.FindGameObjectWithTag("Enemy").transform; // coloca o inimigo como alvo 
        


        zombiagroarea.EnemyEmAggro += EnemyEntrouAggro;
        zombiagroarea.EnemySaiuAggro += EnemySaiuAggro;

        ZombiatackArea.EnemyEntrouAttack += EnemyEntrouAttackArea;
        ZombiatackArea.EnemySaiuAttack += EnemySaiuAttackArea;


        Delete();

    }

    void Update()
    {
        if(IA == true)
        {
            navhunt();
        }
        
        
        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("Enemy").transform;

        if(Vida <= 0)
        {
            //anim.SetBool("death"true);
            Delete2();
        }



    }




    void hunt()   // caça o inimigo
    {
        Vector3 direction = Target.position - transform.position;

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
        Vector3 direction = Target.position - transform.position;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();
        
        
            anim.SetFloat("Horizontal", direction.x); // controla as animações
            anim.SetFloat("Vertical", direction.y);
            anim.SetFloat("speed", direction.magnitude);
          
        
    }

   public void TomaDano(float dano)
    {
        Vida = Vida - dano;
    }

    void Atack()
    {
        Target.GetComponent<EnemyAI>().LevaDano(dano);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }


    public void Delete() //destroi apos 10
    {
      
        Destroy(gameObject, timeDestroy);
    }

    public void Delete2() //fim da vida
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }

    void EnemyEntrouAggro()
    {
        IA = true;
    }
    void EnemySaiuAggro()
    {
       Target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void EnemyEntrouAttackArea()
    {
     
        isAttackingEnemy = true;
        StartCoroutine("Atacar");
    }

    void EnemySaiuAttackArea()
    {
        isAttackingEnemy = false;
        StopCoroutine("Atacar");
    }


}