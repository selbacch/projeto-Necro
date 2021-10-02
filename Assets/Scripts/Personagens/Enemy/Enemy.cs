﻿using System;
using System.Collections;
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
    public Text DanoText;

    public Int32 Vida = 100;
    public float Resfriamento = 2;
    //public Int32 RaioAtaque = 2.5;
    //public Int32 RaioPerigo = 5;
    public Int32 Velocidade = 1;
    public int DanoAtual = 15;
    public int TempoDestruicao = 1;

  

    private float TargetDistance;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    private Vector3 localInicial;
    private bool isHuntingPlayer;
    private bool isAttackingPlayer;
    protected NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
      //  DanoText = this.transform.Find("DanoTexto").gameObject.GetComponent<Text>();
        
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

    private void OnDestroy()
    {
        DeathEvent?.Invoke();
        Debug.Log("Inimigo: base " + this.GetHashCode() + " destroy ");
    }

    // Update is called once per frame
    void Update()
    {

        Hunt();

        //VoltarPosicaoInicial();
        if (Vida <= 0)
        {
            Death = true;
            Anim.SetBool("death", true);

        }
        if (Target != null && Target.tag == "sumon"&& Target.GetComponent<InterfaceAtacavel>().Death == true)
        {
           
                Target = null;
            
        }

    }

    void Hunt()
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

    public void Delete2() //fim da vida
    {
        
        GetComponentInChildren<DropRItens>().DropRandItem();
        Destroy(this.gameObject);          
    }

    public override void SofrerDano(int danoRecebido)
    {
        if (this.Vida <= 0 || !this.gameObject.activeSelf)
            return;
        this.Vida -= danoRecebido;
        
        StartCoroutine(TextoDeDano(danoRecebido));
    }

    IEnumerator TextoDeDano(int danoRecebido)
    {
        DanoText.text = danoRecebido.ToString();
        DanoText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        DanoText.gameObject.SetActive(false);

    }

    public override int Dano()
    {
        return this.DanoAtual;
    }
}

