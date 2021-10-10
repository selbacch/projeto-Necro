using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyCommander : Enemy
{

    public Animator anim;
    public bool Gritou = false;
    public bool IA = false;
    public bool isAttackingEnemy;
 private GameObject[] points;
    private int destPoint = 0;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;

        AreaAtaque.PlayerEntrouAttack += PlayerEntrouAttackArea;
        AreaAtaque.PlayerSaiuAttack += PlayerSaiuAttackArea;
        points = GameObject.FindGameObjectsWithTag("Respawn");
    }

    private void OnDestroy()
    { Debug.Log("Inimigo: commander " + this.GetHashCode() + " destroy ");
        DeathEvent?.Invoke();
       
    }

    void Update()
    {

        if (IA != true)
        {
            patrol();
           
        }
        else { navhunt(); }

        
            

        if (Vida <= 0)
        {
            Death = true;
            anim.SetBool("death", true);
                        
        }
        if ( Target.tag == "sumon" && Target.GetComponent<InterfaceAtacavel>().Death)
        {
            isAttackingEnemy = false;
            Target = null;
            BuscaInimigo2();
            BuscaInimigo();
        }

    }
 
    void BuscaInimigo()//busca player
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = 10f;
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

    void BuscaInimigo2()//busca sumon
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("sumon");
        GameObject closest = null;
        float distance = 10f;
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

            yield return new WaitForSeconds(2f);
        }
    }
    void patrol()
    {
        
        
        

        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].transform.position;
        float distance = 1.1f;

        float distObj = Vector3.Distance(transform.position, points[destPoint].transform.position);
        Debug.Log(distObj);
        if (distObj <= distance)
            
        {
            
            NextPoint();
        }
        
       
    }
    void NextPoint() { destPoint = (destPoint + 1) % points.Length; }

    void navhunt()
    {
        if (Target == null)
            return;
        if (!agent.enabled)
        {
            return;
        }
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

    public void ScreamComander()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity; ;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && go.name != "Enemy Comander")
            {
                closest = go;
                distance = curDistance;
                closest.gameObject.GetComponent<Enemy>().Target = Target;
                Gritou = true;
                anim.SetBool("Grito", false);

            }

        }


    }
    IEnumerator Poison(int Dano, int Tempo)
    {
        for (int i = 0; i < Tempo; i++)
        {
            Debug.Log("veneno");
            SofrerDano(Dano);
            yield return new WaitForSeconds(2);
        }
    }
       
    void PlayerEntrouAggro(GameObject go)
    {

        if (Gritou == false)
        {
            anim.SetBool("Grito", true);
        }
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


    public override int Dano()
    {
        return this.DanoAtual;
    }

}