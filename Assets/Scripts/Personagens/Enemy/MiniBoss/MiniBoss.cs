using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MiniBoss : Enemy
{

    private GameObject alvo;
    public bool isAttackingEnemy;
    public AtackMiniBoss AtackMiniBoss;
    public int Mana = 2;
    public Transform point;
    public GameObject Lacaio0;
    public GameObject Lacaio3;
    public int combo1 = 0;
    public GameObject Projetil;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;
        AtackMiniBoss.Atacke += Atacke;
        AtackMiniBoss.AtackeOut += AtackeOut;
        AreaAtaque.PlayerEntrouAttack += PlayerEntrouAttackArea;
        AreaAtaque.PlayerSaiuAttack += PlayerSaiuAttackArea;

    }

    private void OnDestroy()
    {
        Debug.Log("Inimigo: commander " + this.GetHashCode() + " destroy ");
        DeathEvent?.Invoke();

    }

    void Update()
    {


        if (!Death && Vida <= 0)
        {
            Death = true;
            Anim.SetBool("death", true);
            return;

        }
        if (Mana < 2)
        {
            StartCoroutine(AumentarMana(5f));
        }
       
        if (Target == null)
        {
            isAttackingEnemy = false;
            Target = null;
            BuscaInimigo2();
            AlvoProx();
        }
        navhunt();
    }

    void AlvoProx()//busca player
    {
        Debug.Log("hello player");
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = 10f;//Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance == distance)
            {
                closest = go;
                distance = curDistance;
                StartCoroutine(AtaqueDistance(closest));
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
                StartCoroutine(AtaqueDistance(closest));
            }

        }

    }

    void VeriLacaio()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");


        if (gos.Length <= 1)
        {
            StartCoroutine(ScreamComander());
        }
        else { return; }
    }

    public override IEnumerator Atacar(GameObject gameObject)
    {
        for (; ; )
        {
            if (isAttackingEnemy == true)
            {
                Anim.SetTrigger("atack" + combo1);


            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    void start_combo()
    {


        if (combo1 < 3)
        {
            combo1++;

        }
    }



    void Anim_Finish()
    { combo1 = 0; }

    IEnumerator AumentarMana(float tempo)
    {
        int novoValor = Mana + 1;
        Mana = novoValor > 2 ? 2 : novoValor;
        yield return new WaitForSeconds(tempo);
    }

    void navhunt()
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

    void Atack(GameObject go)
    {
        alvo = go;
        alvo.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }
    IEnumerator AtaqueDistance(GameObject alvo)
    {
        yield return new WaitForSeconds(5f);
        if (Energy < 0)
        {

        }
        else
        {

            Debug.Log("segura");
            GameObject CloneTiro = Instantiate(Projetil, point.position, point.rotation);
            CloneTiro.GetComponent<arrow>().direct = alvo.transform.position - transform.position; ;

            Energy--;
            Energy--;
        }
    }
    IEnumerator ScreamComander()
    {

        yield return new WaitForSeconds(3f);
        if (Energy > 0)
        {

            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player");
            float distance = 20f;//Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance > distance)
                {



                    GameObject Lacaio1 = Instantiate(Lacaio0, point.position, point.rotation, transform.parent);
                    Lacaio1.GetComponent<Enemy>().Vida = 1;
                    GameObject Lacaio2 = Instantiate(Lacaio3, point.position, point.rotation, transform.parent);
                    Lacaio2.GetComponent<Enemy>().Vida = 1;
                    Energy--;
                    Energy--;
                }
            }
        }
    }

    public override void PlayerEntrouAggro(GameObject go)
    {



        Target = go;
    }
    public override void PlayerSaiuAggro(GameObject go)
    {

        Target = null;

        if (go.gameObject.tag == "Player" && isAttackingEnemy != true)
        {
            VeriLacaio();
        }
    }

    public override void PlayerEntrouAttackArea(GameObject go)
    {
        Target = go;
        isAttackingEnemy = true;
        StartCoroutine(Atacar(go));
    }

    public override void PlayerSaiuAttackArea(GameObject go)
    {
        isAttackingEnemy = false;
        StopCoroutine(Atacar(go));

    }

    void Atacke(GameObject go)
    {
        Atack(go);
    }
    void AtackeOut(GameObject go)
    {
        alvo = null;
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