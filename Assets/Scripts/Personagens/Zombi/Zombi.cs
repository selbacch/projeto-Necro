using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Zombi : MonoBehaviour
{

    public Animator anim;

    public Transform Target = null;
    public float TargetDistance;
    private float timeDestroy = 50;
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


        BuscaInimigo();





        Delete();

    }

    void Update()
    {
        if (IA == true)
        {
            navhunt();
        }


        if (Target == null)
        {
            BuscaInimigo();
            Target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        if (Vida <= 0)
        {
            //anim.SetBool("death"true);
            Delete2();
        }

        Debug.Log(Target);

    }


    void BuscaInimigo()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        Target = closest.transform;
        if (closest == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Debug.Log(Target);



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
        anim.SetFloat("Speed", direction.magnitude);


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

    public void EnemyEntrouAggro()
    {
        IA = true;
    }
    public void EnemySaiuAggro()
    {
        Target = GameObject.FindGameObjectWithTag("Enemy").transform;

    }

    public void EnemyEntrouAttackArea()
    {

        isAttackingEnemy = true;
        StartCoroutine("Atacar");
    }

    public void EnemySaiuAttackArea()
    {
        isAttackingEnemy = false;
        StopCoroutine("Atacar");
    }


}