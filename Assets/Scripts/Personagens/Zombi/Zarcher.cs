using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zarcher : Enemy
{



    
    public Transform point;
    public GameObject tiro1;
    
   
    public Vector3 Direct;
    public bool IA;
    public EnemyAttackArea2 AreaAtaque2;
   
    
  
    void Start()
    {

 
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        AreaPerigo.PlayerEntrouAggro += PlayerEntrouAggro;
        AreaPerigo.PlayerSaiuAggro += PlayerSaiuAggro;

        AreaAtaque.PlayerEntrouAttack += PlayerEntrouAttackArea;
        AreaAtaque.PlayerSaiuAttack += PlayerSaiuAttackArea;


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


        

    }

    void Update()
    {





        if (IA == true)
        {
          
        }


       
        if (Vida <= 0)
        {
            //anim.SetBool("death"true);
            Delete();
        }

       
    }











    IEnumerator Atacar(GameObject gameObject)//atira
    {
        Ponta();
  
        
            yield return new WaitForSeconds(2f);
        Anim.SetBool("atack", true); 
            yield return new WaitForSeconds(1f);

        
    }
    void CallBackAnimacaoAtira()
    {
        Anim.SetBool("atack", false);
        Anim.SetBool("esconde", false);
    }

    void TradeTag()
    {
        gameObject.tag = "Enemy";
    }
    void RemoveTag()
    {
        gameObject.tag = "Untagged";
    }

    void Ponta() // vira para o lado que esta o inimigo
    {
        if (Target == null)
            return;
        Vector3 direction1 = Target.gameObject.transform.position - transform.position;
        direction1.z = 0;
        float distanceToTarget = direction1.magnitude;

        Direct = Target.gameObject.transform.position - transform.position; 
     
    }


    void Atack()
    {

        // Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
        GameObject CloneTiro = Instantiate(tiro1, point.position, point.rotation);
        CloneTiro.GetComponent<arrow>().direct = Direct ;

    }
    
    


    void Delete() //destroi apos 10
    {

        Destroy(gameObject);
    }

    

    void PlayerEntrouAggro(GameObject go)
    {
        Anim.SetBool("esconde", false);
    }
    void PlayerSaiuAggro(GameObject go)
    {
        Anim.SetBool("esconde", true);
    }

   

    void PlayerEntrouAttackArea(GameObject go)
    {
        Target = go.gameObject;
        Anim.SetBool("esconde", true);
        isAttackingPlayer = true;
        StartCoroutine(Atacar(go));
    }

    void PlayerSaiuAttackArea(GameObject go)
    {
        Target = null;
        Anim.SetBool("esconde", false);
        isAttackingPlayer = false;
        StartCoroutine(Atacar(go));
    }




    public override void Atacar(int danoInflingido)
    {
        throw new NotImplementedException();
    }

    public override void SofrerDano(int danoRecebido)
    {
        if (this.Vida <= 0 || !this.gameObject.activeSelf)
            return;
        this.Vida -= danoRecebido;

        StartCoroutine(FeedbackDano(danoRecebido));
    }

    public override int Dano()
    {
        return this.DanoAtual;
    }

}
