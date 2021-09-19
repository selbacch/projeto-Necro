using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PrisionAttack : MonoBehaviour
{
    public GameObject habilidadeGameobject;
    public int DanoAtual;
    private GameObject eneMy;
    private bool estaAtivo;
    private InterfaceAtacavel atacavelEnemy;
    // Start is called before the first frame update
    void Start()
    {
        estaAtivo = false;
        atacavelEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (habilidadeGameobject == null)
        {
            return;
        }

        if (!habilidadeGameobject.activeSelf)
        {
            eneMy.GetComponent<NavMeshAgent>().enabled = true;
            MorteInimigo();
        }

        if (estaAtivo &&(eneMy == null || atacavelEnemy.Death))
        {
            MorteInimigo();
        }

    }

    private void OnDestroy()
    {
        Debug.Log("prisao destruida");
        if (atacavelEnemy)
        {
            atacavelEnemy.DeathEvent -= MorteInimigo;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy") && !estaAtivo)
        {
            eneMy = other.gameObject;
            other.GetComponent<NavMeshAgent>().enabled = false;
            atacavelEnemy = eneMy.GetComponent<InterfaceAtacavel>();
            atacavelEnemy.DeathEvent += MorteInimigo;
            estaAtivo = true;
        }

    }

    void MorteInimigo()
    {
        Destroy(this.gameObject);
       
    }


    public void atack()
    {
        if (atacavelEnemy != null && eneMy.tag == "Enemy" && !atacavelEnemy.Death)
        {
            eneMy.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
            
        }
    }

}
