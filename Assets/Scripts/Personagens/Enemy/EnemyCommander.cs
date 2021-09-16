using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyCommander : Enemy
{

    public Animator anim;
    public bool Gritou = false;
    public bool death = false;
    public bool IA;
    public bool isAttackingEnemy;
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
            anim.SetBool("death", true);

            gameObject.tag = "Untagged";
        }
        if (Target != null && Target.tag == "sumon")
        {
            if (Target.GetComponent<Zombi>().death == true)//verifica se esta morto
            {

                isAttackingEnemy = false;
                Target = null;
                BuscaInimigo2();
                BuscaInimigo();
            }
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

    void Delete2() //fim da vida
    {
        GameObject.Destroy(gameObject);
        //gameObject.GetComponentInChildren<DropRItens>().DropObgItem();
        gameObject.GetComponentInChildren<DropRItens>().DropRandItem();
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