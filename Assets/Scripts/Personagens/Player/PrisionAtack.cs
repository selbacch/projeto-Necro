using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PrisionAtack : MonoBehaviour
{
    public GameObject temp;
    public int DanoAtual;
   private GameObject eneMy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
        if (!temp.activeSelf)
        {
            eneMy.GetComponent<NavMeshAgent>().enabled = true;
            float timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
        }

        if (eneMy.tag == "Enemy")
        {
            if (eneMy.GetComponent<Enemy2>().death == true)
            {

                float timeDestroy = 0f;
                Destroy(gameObject, timeDestroy);

            }
           
        }


    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {

            eneMy = other.gameObject;
            other.GetComponent<NavMeshAgent>().enabled = false;

        }

    }



   public void atack()
    {
        eneMy.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);
    }
}
