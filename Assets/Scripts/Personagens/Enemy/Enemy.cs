using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : InterfaceAtacavel
{
    public Animator Anim;
    public GameObject Target;
    public EnemyAttackArea AreaAtaque;
    public EnemyAggroArea AreaPerigo;
    public UnityEngine.AI.NavMeshAgent nave;

    public Int32 Vida = 100;
    public float Resfriamento = 2;
    //public Int32 RaioAtaque = 2.5;
    //public Int32 RaioPerigo = 5;
    public Int32 Velocidade = 1;
    public int DanoAtual = 15;



    private float TargetDistance;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    private Vector3 localInicial;
    private bool isHuntingPlayer;
    private bool isAttackingPlayer;
    // Start is called before the first frame update
    void Start()
    {

        TargetDistance = 0;

        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;

        AreaAtaque.PlayerEntrouAttack += PlayerEntrouAttackArea;
        AreaAtaque.PlayerSaiuAttack += PlayerSaiuAttackArea;
        

        isHuntingPlayer = false;
        isAttackingPlayer = false;
        localInicial = transform.position;
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        

    }

    // Update is called once per frame
    void Update()
    {

            Hunt();

        //VoltarPosicaoInicial();
        if (Vida <1)
        {
            Destroy(this.gameObject);
        }
            
    }


    void Hunt()
    {
        if (Target == null)
            return;
        gameObject.GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);
        Vector3 direction = Target.gameObject.transform.position - transform.position;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();

        Anim.SetFloat("Horizontal", direction.x); // controla as animações
        Anim.SetFloat("Vertical", direction.y);
        Anim.SetFloat("Speed", direction.magnitude);
    }

    IEnumerator Atacar(GameObject gameObject)
    {
        for (; ; )
        {
            if (Target != null)
            {
                // Anim.SetTrigger("atack");
                InterfaceAtacavel atacavel;

               if( gameObject.TryGetComponent<InterfaceAtacavel>(out atacavel))
                {
                    atacavel.SofrerDano(this.Dano());
                }

               
            }
            {

                StopCoroutine("Atacar");
                isHuntingPlayer = false;
                isAttackingPlayer = false;
            }

            yield return new WaitForSeconds(Resfriamento);
        }
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
        float distanceWantsToMoveThisFrame = Velocidade * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);
        MoveCharacter(actualMovementThisFrame * direction);
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
    void AtackAnim()
    {
       
        Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    void PlayerEntrouAggro(GameObject go)
    {
        isHuntingPlayer = true;
        Target = go;
    }
    void PlayerEmAttack(GameObject go)
    {
        isHuntingPlayer = true;
        Target = go;
    }
    void PlayerSaiuAggro(GameObject go)
    {
        isHuntingPlayer = false;
    }

    void PlayerEntrouAttackArea(GameObject go)
    {
        isAttackingPlayer = true;
        StartCoroutine(Atacar(go));
    }

    void PlayerSaiuAttackArea(GameObject go)
    {
        isAttackingPlayer = false;
        StopCoroutine(Atacar(go));
    }
    public void Poisoned(int Dano, int Tempo)
    {
        StartCoroutine(Poison(Dano, Tempo));
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

