using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MiniBoss : Enemy
{

    
  
    
    public bool isAttackingEnemy;
    
    public int Energy = 2;
    public Transform point;
    public GameObject Lacaio0;
    public GameObject Lacaio3;
    public int combo1=0;
    public GameObject Projetil;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;

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

       
         navhunt(); 

        if(Energy < 2)
        {
            PEnergy();
        }
        if(Energy > 2) { Energy = 2; }


        if (Vida <= 0)
        {
            Death = true;
            Anim.SetBool("death", true);

        }
        if (Target != null && Target.tag == "sumon" && Target.GetComponent<InterfaceAtacavel>().Death)
        {
            isAttackingEnemy = false;
            Target = null;
            BuscaInimigo2();
            BuscaInimigo();
        }

    }

    void BuscaInimigo()//busca player
    {
        Debug.Log("hello player");
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
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
                AtaqueDistance(closest.gameObject);
            }

        }

        

    }

    void BuscaInimigo2()//busca sumon
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("sumon");
        GameObject closest = null;
        float distance = 80f;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                AtaqueDistance(closest.gameObject);
            }

        }
        
    }

    void VeriLacaio()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
       
       
        if (gos.Length <= 0)
        {
            StartCoroutine(ScreamComander());
        }
        else { return; }
    }

    IEnumerator Atacar(GameObject gameObject)
    {
        for (; ; )
        {
            if (isAttackingEnemy == true)
            {
                Anim.SetTrigger("atack"+combo1);
                

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
    void PEnergy()
    {
        StartCoroutine(PlusEnergy(3f));
    }

    IEnumerator PlusEnergy(float tempo)
    {
        Energy = Energy + 1;
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


        Anim.SetFloat("Horizontal", direction.x); // controla as anima��es
        Anim.SetFloat("Vertical", direction.y);
        Anim.SetFloat("Speed", direction.magnitude);

    }

    void Atack()
    {
        if (Target == null)
            return;
        Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }
    public void AtaqueDistance(GameObject alvo)
    {
        if (Energy < 2 || Death)
        {
            return;
        }
        Debug.Log("segura");
        GameObject CloneTiro = Instantiate(Projetil, point.position, point.rotation);
        CloneTiro.GetComponent<arrow>().direct = alvo.transform.position - transform.position; ;

        Energy = Energy - 2;

    }
    IEnumerator ScreamComander()
    {

        yield return new WaitForSeconds(3f);
        if (Energy< 2 || Death)
        {
            
        }

        GameObject Lacaio1 = Instantiate(Lacaio0, point.position, point.rotation, transform.parent);
        Lacaio1.GetComponent<Enemy>().Vida = 1;
        GameObject Lacaio2 = Instantiate(Lacaio3, point.position, point.rotation, transform.parent);
        Lacaio2.GetComponent<Enemy>().Vida = 1;
        Energy = Energy- 2;

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

    void PlayerEntrouAggro(GameObject go)
    {

     
        Target = go;
    }
    void PlayerSaiuAggro(GameObject go)
    {
      
        Target = null;
        if (go.gameObject.tag == "Player"&& isAttackingEnemy !=true)
        {
            VeriLacaio();
        }
    }

    void PlayerEntrouAttackArea(GameObject go)
    {
        Target = go;
        isAttackingEnemy = true;
        StartCoroutine(Atacar(go));
    }

    void PlayerSaiuAttackArea(GameObject go)
    {
        isAttackingEnemy = false;
        StopCoroutine(Atacar(go));

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