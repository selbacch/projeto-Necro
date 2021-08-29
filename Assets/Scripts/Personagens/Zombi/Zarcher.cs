using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zarcher : InterfaceAtacavel
{

    public Animator anim;

    public GameObject Target;
    public GameObject Player;
    public Transform point;
    public GameObject tiro1;
    public float TargetDistance;
    private float timeDestroy = 50;
    public Vector3 Direct;
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





        if (IA == true)
        {
            navhunt();
        }


        if (Target == null)
        {
            BuscaInimigo();
          
        }
        if (Vida <= 0)
        {
            //anim.SetBool("death"true);
            Delete2();
        }

        if (Direct.magnitude >  4)
        {
            EnemyEntrouAttackArea2(Target);
        }

    }


    void BuscaInimigo()//busca inimigo 
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
                Target = closest.gameObject;
            }
            if (diff.magnitude > 10f)
            { Target = null; }
        }





    }









    IEnumerator Atacar(GameObject gameObject)//atira
    {
        for (; ; )
        {
            anim.SetTrigger("atack");

            yield return new WaitForSeconds(10f);
        }
    }



    IEnumerator Atacar2(GameObject gameObject)//ataca de perto
    {
        for (; ; )
        {
            anim.SetTrigger("atack2");

            yield return new WaitForSeconds(0.5f);
        }
    }

    void navhunt()//pesegue o jogador
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
        Vector3 direction = Player.gameObject.transform.position - transform.position;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();
        if (Target == null)
        {

            anim.SetFloat("Horizontal", direction.x); // controla as animações
            anim.SetFloat("Vertical", direction.y);
            anim.SetFloat("Speed", direction.magnitude);
        }
        else { Ponta(); }

    }
    void Ponta() // vira para o lado que esta o inimigo
    {
        if (Target == null)
            return;
        Vector3 direction1 = Target.gameObject.transform.position - transform.position;
        direction1.z = 0;
        float distanceToTarget = direction1.magnitude;

        Direct = Target.gameObject.transform.position - transform.position; 
        anim.SetFloat("Horizontal", direction1.x); // controla as animações
        anim.SetFloat("Vertical", direction1.y);
        anim.SetFloat("Speed", direction1.magnitude);
    }


    void Atack()
    {

        // Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
        GameObject CloneTiro = Instantiate(tiro1, point.position, point.rotation);
        CloneTiro.GetComponent<arrow>().direct = Direct ;

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

        Destroy(gameObject, timeDestroy);
    }

    void Delete2() //fim da vida
    {
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
        StartCoroutine(Atacar2(go));
    }

    void EnemyEntrouAttackArea2(GameObject go)
    {
        isAttackingEnemy = true;
        StartCoroutine(Atacar(go));
    }



    void EnemySaiuAttackArea(GameObject go)
    {
        isAttackingEnemy = false;
        StopCoroutine(Atacar2(go));
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
