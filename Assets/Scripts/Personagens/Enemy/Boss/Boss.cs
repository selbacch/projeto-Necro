using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public bool Invunevarel = true;
    public int TempoInvocarMinion;
    public GameObject minionPrefab;
    public Transform spotInvocacao;

    private GameObject minionAtivo;

    // Start is called before the first frame update
    void Start()
    {
        ConfigStart();
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

        if (Target == null)
        {
            Target = this.AreaPerigo.ObterProximoTarget();
        }

        Cacar();
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
            if (Target != null && agent.remainingDistance < 30)
            {
                Anim.SetTrigger("atack");

            }
            {
                StopCoroutine("Atacar");
                StopCoroutine(InvocarMinion());
                isHuntingPlayer = false;
                isAttackingPlayer = false;
            }
            yield return new WaitForSeconds(Resfriamento);
        }
    }

    public override void PlayerSaiuAttackArea(GameObject go)
    {
        isAttackingPlayer = false;
        StopCoroutine(Atacar(go));
        StopCoroutine(InvocarMinion());
    }

    public override void PlayerEntrouAttackArea(GameObject go)
    {
        isAttackingPlayer = true;
        StartCoroutine(Atacar(go));
        StartCoroutine(InvocarMinion());
    }

    public override void SofrerDano(int danoRecebido)
    {
        if (this.Vida <= 0 || !this.gameObject.activeSelf)
        {
            return;
        }


        if (Invunevarel)
        {
            StartCoroutine(TextoDeMiss());
            return;
        }
        this.Vida -= danoRecebido;
        StartCoroutine(TextoDeDano(danoRecebido));
    }

    protected IEnumerator TextoDeMiss()
    {
        DanoText.text = "MISS";
        DanoText.color = Color.white;
        DanoText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        DanoText.gameObject.SetActive(false);

    }


    IEnumerator InvocarMinion()
    {
        for (; ; )
        {
            if (minionAtivo == null)
            {
                minionAtivo = Instantiate(this.minionPrefab, this.spotInvocacao.position, Quaternion.identity);
                minionAtivo.GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");
            }
            yield return new WaitForSeconds(TempoInvocarMinion);
        }
    }

}
