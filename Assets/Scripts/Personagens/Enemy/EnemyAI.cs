using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public Transform Target;
    public EnemyAttackArea AreaAtaque;
    public EnemyAggroArea AreaPerigo;
    public Animator anim;

    private float timeDestroy = 0;
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
        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;

        AreaAtaque.PlayerEntrouAttack += PlayerEntrouAttackArea;
        AreaAtaque.PlayerSaiuAttack += PlayerSaiuAttackArea;
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

    public void PlayerEntrouAggro(GameObject go)
    {
        isHuntingPlayer = true;
    }
    public void PlayerSaiuAggro(GameObject go)
    {
        // Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void PlayerEntrouAttackArea(GameObject go)
    {
        isAttackingPlayer = true;
        StartCoroutine("Atacar");
    }

    public void PlayerSaiuAttackArea(GameObject go)
    {
        isAttackingPlayer = false;
        StopCoroutine("Atacar");
    }


    void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("sumon").GetComponent<Zombi>().Target = null;

    }


}