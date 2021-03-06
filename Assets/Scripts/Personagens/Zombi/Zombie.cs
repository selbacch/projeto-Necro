using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : InterfaceAtacavel
{

    public Animator anim;
    public GameObject Target = null;
    public float TargetDistance;
    private float timeDestroy = 50;
    public bool IA;
    public zombiagroarea AreaPerigo;
    public ZombiatackArea AreaAtaque;
    public bool isAttackingEnemy;
    public Int32 Vida = 100;
    public int DanoAtual;
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        AreaPerigo.EnemyEntrouAggro += EnemyEntrouAggro;
        AreaPerigo.EnemySaiuAggro += EnemySaiuAggro;

        AreaAtaque.EnemyEntrouAttack += EnemyEntrouAttackArea;
        AreaAtaque.EnemySaiuAttack += EnemySaiuAttackArea;

        BuscaInimigo();

        Delete();
    }

    void Update()
    {
        if (Vida <= 0)
        {
            Death = true;
            anim.SetBool("death", true);
        }

        if (IA == true)
        {
            navhunt();
        }

        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player").gameObject;
        }
        if (Target.tag == "Player")
        {
            isAttackingEnemy = false;
            EnemySaiuAttackArea(Target);
            BuscaInimigo();           
        }
        
        if (Target.tag == "Enemy" && Target.GetComponent<InterfaceAtacavel>().Death)
        {

            isAttackingEnemy = false;
            Target = null;

        }

    }

    void BuscaInimigo()
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = 8f;//Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                Target = closest.gameObject;
            }
            if (diff.magnitude > 10f)
            { Target = GameObject.FindGameObjectWithTag("Player").gameObject; }
        }





    }

    IEnumerator Atacar(GameObject gameObject)
    {
        if (isAttackingEnemy == true)
        {
            for (; ; )
            {
                anim.SetTrigger("atack");

                yield return new WaitForSeconds(1f);
            }
        }
    }


    void navhunt()
    {
        if (Target == null)
            return;
        gameObject.GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);
        Vector2 direction = Target.gameObject.transform.position - transform.position;
        //direction.z = 0;
        float distanceToTarget = direction.magnitude -1;

        direction.Normalize();


        anim.SetFloat("Horizontal", direction.x); // controla as animações
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", distanceToTarget);
        if (direction.y > 0)
        {

            anim.SetInteger("idle", 1);


        }
        if (direction.y < 0)
        {

            anim.SetInteger("idle", -1);


        }
        if (direction.x < 0)
        {
            anim.SetInteger("idle", 2);


        }

        if (direction.x > 0)
        {
            anim.SetInteger("idle", -2);


        }
        if (direction.x < 0 && direction.y < 0)
        {
            anim.SetInteger("idle", 1);

        }
        if (direction.x > 0 && direction.y > 0)
        {
            anim.SetInteger("idle", 1);

        }
        if (direction.x < 0 && direction.y > 0)
        {
            anim.SetInteger("idle", -1);

        }
        if (direction.x > 0 && direction.y < 0)
        {
            anim.SetInteger("idle", -1);

        }
    }

    void Atack()
    {
       
        if (Target == null || Target.tag == "Player")
            return;
        Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    void Delete() //destroi apos 10
    {

        Destroy(gameObject, timeDestroy);
    }

    void Delete2() //fim da vida
    {
        IA = false;
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }

    void EnemyEntrouAggro(GameObject go)
    {
        IA = true;
        Target = go;
    }
    void EnemySaiuAggro(GameObject go)
    {
        IA = true;
    }

    void EnemyEntrouAttackArea(GameObject go)
    {
        isAttackingEnemy = true;
        StartCoroutine(Atacar(go));
    }

    void EnemySaiuAttackArea(GameObject go)
    {
        isAttackingEnemy = false;
        StopCoroutine(Atacar(go));
    }

    public override void Atacar(int danoInflingido)
    {
        throw new NotImplementedException();
    }

    public override void SofrerDano(int danoRecebido)
    {
        this.Vida -= danoRecebido;
    }

    public override int Dano()
    {
        return this.DanoAtual;
    }

}