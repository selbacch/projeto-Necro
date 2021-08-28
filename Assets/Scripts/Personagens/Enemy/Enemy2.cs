using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemy2 : InterfaceAtacavel
{

    public Animator anim;

    public GameObject Target = null;
    public float TargetDistance;

    public bool death = false;
    public bool IA;
    public EnemyAttackArea AreaAtaque;
    public EnemyAggroArea AreaPerigo;
    public bool isAttackingEnemy;
    public Int32 Vida = 100;
    public int DanoAtual;
    void Start()
    {

        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;

        AreaAtaque.PlayerEntrouAttack += PlayerEntrouAttackArea;
        AreaAtaque.PlayerSaiuAttack += PlayerSaiuAttackArea;

       


        

    }

    void Update()
    {





        if (IA == true)
        {
            navhunt();
        }


       
        if (Vida <= 0)
        { 
            death = true;
            anim.SetBool("death",true);
           
            gameObject.tag = "Default";
        }

        

        if (Target.GetComponent<Zombi>().death == true)
        {
           
            isAttackingEnemy = false;
            Target = null;
            BuscaInimigo2();
            BuscaInimigo();
        }


    }


    void BuscaInimigo()
    {
        
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = 20f;
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
            
        }





    }

    void BuscaInimigo2()
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("sumon");
        GameObject closest = null;
        float distance = 20f;
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

        }





    }


    IEnumerator Atacar(GameObject gameObject)
    {
        for (; ; )
        {
            anim.SetTrigger("atack");

            yield return new WaitForSeconds(0.5f);
        }
    }


    void navhunt()
    {
        if (Target == null)
            return;
        gameObject.GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);
        Vector3 direction = Target.gameObject.transform.position - transform.position;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();


        anim.SetFloat("Horizontal", direction.x); // controla as animações
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", direction.magnitude);


    }



    void Atack()
    {
        if (Target == null)
            return;
        Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }


 

    void Delete2() //fim da vida
    {
        GameObject.Destroy(gameObject);
    }

    void PlayerEntrouAggro(GameObject go)
    {
        IA = true;
        Target = go;
    }
    void PlayerSaiuAggro(GameObject go)
    {
        IA = true;
    }

    void PlayerEntrouAttackArea(GameObject go)
    {
        isAttackingEnemy = true;
        StartCoroutine(Atacar(go));
    }

    void PlayerSaiuAttackArea(GameObject go)
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