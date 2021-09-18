using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyArcher : InterfaceAtacavel
{

    public Animator anim;

    public GameObject Target = null;
    public float TargetDistance;
    public Transform point;
    public GameObject tiro1;
    public bool IA;
    public EnemyAttackArea AreaAtaque;
    public EnemyAggroArea AreaPerigo;
    public bool isAttackingEnemy;
    public Int32 Vida = 100;
    public int DanoAtual;
    public Vector3 Direct;
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
            Death = true;
            anim.SetBool("death", true);
        }

        if (Target.GetComponent<Zombie>().Death == true)
        {

            isAttackingEnemy = false;
            Target = null;
            BuscaInimigo2();
            BuscaInimigo();
        }
        if (Direct.magnitude > 1)
        {
            PlayerEntrouAttackArea2(Target);
        }
        Debug.Log(Direct.magnitude);
    }


    void BuscaInimigo()//busca player
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

    void BuscaInimigo2()//busca inimigo
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

            yield return new WaitForSeconds(10f);
        }
    }



    IEnumerator Atacar2(GameObject gameObject)
    {
        for (; ; )
        {
            anim.SetTrigger("atack2");
            gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 0;
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

        Direct = Target.gameObject.transform.position - transform.position;


        anim.SetFloat("Horizontal", direction.x); // controla as animações
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", direction.magnitude);


    }


    void Atack()
    {

        
        GameObject CloneTiro = Instantiate(tiro1, point.position, point.rotation);
        CloneTiro.GetComponent<arrow>().direct = Direct;

    }
    void Atack2()
    {

        Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);

    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }


    void Delete() //destroi apos 10
    {

        Destroy(gameObject, 0);
    }



    void PlayerEntrouAggro(GameObject go)
    {
        IA = true;
        Target = go;
    }
    void PlayerSaiuAggro(GameObject go)
    {
        IA = true;
        StopCoroutine(Atacar2(go));
        gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 2;
    }

    void PlayerEntrouAttackArea(GameObject go)
    {
        isAttackingEnemy = true;
        StartCoroutine(Atacar2(go));
    }

    void PlayerEntrouAttackArea2(GameObject go)
    {
        isAttackingEnemy = true;
        StartCoroutine(Atacar(go));
    }



    void PlayerSaiuAttackArea(GameObject go)
    {
        isAttackingEnemy = false;
        StopCoroutine(Atacar2(go));
        gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 2;
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