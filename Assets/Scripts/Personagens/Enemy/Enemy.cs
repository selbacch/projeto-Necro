using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : InterfaceAtacavel
{
    public Animator Anim;
    public GameObject Target;
    public EnemyAttackArea AreaAtaque;
    public EnemyAggroArea AreaPerigo;
    public UnityEngine.AI.NavMeshAgent nave;

    public Int32 Vida = 100;
    public float Resfriamento = 2;
    public Int32 RaioAtaque = 3;
    //public Int32 RaioPerigo = 5;
    public Int32 Velocidade = 1;
    public int DanoAtual = 15;
    public int TempoDestruicao = 1;

    protected float TargetDistance;
    protected float _distanceToTarget;
    protected float _distanceWantsToMoveThisFrame;
    protected Vector3 localInicial;
    protected bool isHuntingPlayer;
    protected bool isAttackingPlayer;
    protected NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        ConfigStart();
    }

    private void OnDestroy()
    {
        DeathEvent?.Invoke();
        Debug.Log("Inimigo: base " + this.GetHashCode() + " destroy ");
    }

    // Update is called once per frame
    void Update()
    {

        //VoltarPosicaoInicial();
        if (Vida <= 0)
        {
            Death = true;
            Anim.SetBool("death", true);
            Target = null;
            return;

        }
        if (Target != null && Target.tag == "sumon" && Target.GetComponent<InterfaceAtacavel>().Death == true)
        {
            Target = null;
        }

        if (Target == null)
        {
            Target = this.AreaPerigo.ObterProximoTarget();
        }

        Cacar();

    }
    protected void ConfigStart()
    {
        TargetDistance = 0;

        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;

        AreaAtaque.PlayerEntrouAttack += PlayerEntrouAttackArea;
        AreaAtaque.PlayerSaiuAttack += PlayerSaiuAttackArea;


        isHuntingPlayer = false;
        isAttackingPlayer = false;
        localInicial = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    protected void Cacar()
    {
        if (Target == null)
            return;

        if (!agent.enabled)
        {
            return;
        }
        agent.SetDestination(Target.transform.position);
        Vector3 direction = Target.gameObject.transform.position - transform.position;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();

        Anim.SetFloat("Horizontal", direction.x); // controla as animações
        Anim.SetFloat("Vertical", direction.y);
        Anim.SetFloat("Speed", direction.magnitude);
    }

    public virtual IEnumerator Atacar(GameObject gameObject)
    {
        for (; ; )
        {
            if (Target != null && agent != null && agent.enabled && agent.remainingDistance < 30)
            {
                Anim.SetTrigger("atack");

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

    public IEnumerator Poison(int Dano, int Tempo)
    {
        for (int i = 0; i < Tempo; i++)
        {
            Debug.Log("veneno");
            
            StartCoroutine(FeedbackDano(Dano));
            yield return new WaitForSeconds(2);
        }

    }
    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    public virtual void PlayerEntrouAggro(GameObject go)
    {
        isHuntingPlayer = true;
        Target = go;
    }
    void PlayerEmAttack(GameObject go)
    {
        isHuntingPlayer = true;
        Target = go;
    }
    public virtual void PlayerSaiuAggro(GameObject go)
    {
        isHuntingPlayer = false;
    }

    public virtual void PlayerEntrouAttackArea(GameObject go)
    {
        isAttackingPlayer = true;
        StartCoroutine(Atacar(go));
    }

    public virtual void PlayerSaiuAttackArea(GameObject go)
    {
        isAttackingPlayer = false;
        StopCoroutine(Atacar(go));
    }
    public virtual void Poisoned(int Dano, int Tempo)
    {
        StartCoroutine(Poison(Dano, Tempo));
    }
    public override void Atacar(int danoInflingido)
    {
        throw new NotImplementedException();
    }

    public void Delete() //fim da vida
    {
        
        Destroy(this.gameObject);
    }

    public override void SofrerDano(int danoRecebido)
    {
        if (this.Vida <= 0 || !this.gameObject.activeSelf)
            return;
        this.Vida -= danoRecebido;

        StartCoroutine(FeedbackDano(danoRecebido));
    }

    public virtual void callbackAnimacaoAtaque()
    {
        if (Target != null && agent.remainingDistance < this.RaioAtaque)
        {
            Debug.Log(agent.remainingDistance + " ataque " + this.RaioAtaque);
            Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);

        }

    }

    public override int Dano()
    {
        return this.DanoAtual;
    }
}

