using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PrisionAtack : MonoBehaviour
{
    public GameObject habilidadeGameobject;
    public int DanoAtual;
    private GameObject eneMy;
    // Start is called before the first frame update
    void Start()
    {

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
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        if (eneMy)
        {
            eneMy.GetComponent<Enemy>().DeathEvent -= MorteInimigo;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {

            eneMy = other.gameObject;
            other.GetComponent<NavMeshAgent>().enabled = false;
            eneMy.GetComponent<Enemy>().DeathEvent += MorteInimigo;
        }

    }

    void MorteInimigo()
    {
        Destroy(this.gameObject);
    }


    public void atack()
    {
        if (eneMy != null && eneMy.tag == "Enemy" && !eneMy.GetComponent<Enemy>().Death)
        {
            eneMy.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
        }
    }

}
