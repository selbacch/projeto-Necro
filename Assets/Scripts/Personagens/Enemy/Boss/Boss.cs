using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public bool Invunevarel = true;

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
        DanoText.color = Color.gray;
        DanoText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        DanoText.gameObject.SetActive(false);

    }

}
