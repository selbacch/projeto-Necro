using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public bool Invunevarel = true;
    public int TempoInvocarMinion;
    public GameObject minionPrefab;
    public Transform spotInvocacao;
    public bool bossIniciado;
    public EnemyStartArea areaStart;

    private GameObject minionAtivo;

    // Start is called before the first frame update
    void Start()
    {
        ConfigStart();
        bossIniciado = false;
        areaStart.PlayerEntrouStartArea = PlayerEntrouStartArea;

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

        }

        Invunevarel = minionAtivo != null && !minionAtivo.GetComponent<InterfaceAtacavel>().Death;

        if (Target != null && Target.tag == "sumon" && Target.GetComponent<InterfaceAtacavel>().Death == true)
        {
            Target = null;
        }

        if (bossIniciado && Target == null)
        {
            Target = this.AreaPerigo.ObterProximoTarget();
        }

        if (bossIniciado)
        {
            Cacar();
        }

    }

    private void OnDestroy()
    {
        DeathEvent?.Invoke();
        Debug.Log("Inimigo: base " + this.GetHashCode() + " destroy ");
    }

    public override IEnumerator Atacar(GameObject gameObject)
    {
        for (; ; )
        {
            if (gameObject != null && isAttackingPlayer)
            {
                Anim.SetTrigger("atack");
                InterfaceAtacavel inAtacck = gameObject.GetComponent<InterfaceAtacavel>();
                inAtacck.SofrerDano(this.DanoAtual);
                
            }
            else
            {
                StopCoroutine("Atacar");
                isHuntingPlayer = false;
                isAttackingPlayer = false;
            }
            yield return new WaitForSeconds(Resfriamento);
        }
    }

    public override void PlayerSaiuAttackArea(GameObject go)
    {
        if (!bossIniciado)
        {
            return;
        }
        isAttackingPlayer = false;
        StopCoroutine(Atacar(go));
       
    }

    public override void PlayerEntrouAttackArea(GameObject go)
    {
        if (!bossIniciado)
        {
            return;
        }
        isAttackingPlayer = true;
        StartCoroutine(Atacar(go));
    }

    public override void PlayerEntrouAggro(GameObject go)
    {
        if (!bossIniciado)
        {
            return;
        }
        Debug.Log("player entrou na aggro");
        isHuntingPlayer = true;
        Target = go;
        StartCoroutine(InvocarMinion());
    }

    public override void PlayerSaiuAggro(GameObject go)
    {
        base.PlayerSaiuAggro(go);
        StopCoroutine(InvocarMinion());
    }

    public override void SofrerDano(int danoRecebido)
    {


        if (this.Vida <= 0 || !this.gameObject.activeSelf)
        {
            return;
        }
        if (!bossIniciado)
        {
            return;
        }
        if (Invunevarel)
        {
            StartCoroutine(FeedbackInfo("MISS"));
            return;
        }
        this.Vida -= danoRecebido;
        StartCoroutine(FeedbackDano(danoRecebido));
    }

    IEnumerator InvocarMinion()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(TempoInvocarMinion);
            if (minionAtivo == null)
            {
                minionAtivo = Instantiate(this.minionPrefab, this.spotInvocacao.position, Quaternion.identity);
                minionAtivo.GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");
            }

        }
    }

    private void PlayerEntrouStartArea(GameObject ob)
    {
        bossIniciado = true;
        StartCoroutine(InvocarMinion());
    }
}
