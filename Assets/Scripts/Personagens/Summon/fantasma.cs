using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fantasma : Summon
{


    public Animator anim;
   public float speed;
    public float time;
    public GameObject[] gos;
    public GameObject Target = null;
    private GameObject  anterior;

    private void Start()
    {
        BuscaInimigo();
        Delete(time);
    }




    private void Update()
    {
        navhunt();
    }

    void BuscaInimigo()
    {

      
        gos = GameObject.FindGameObjectsWithTag("Enemy") ;
        GameObject closest = null;
        float distance = 8f;//Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
           
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                    Target = closest.gameObject;
                anterior = closest.gameObject;

                }
            
        }





    }



    void BuscaInimigo2()
    {


        
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = anterior.transform.position;
        foreach (GameObject go in gos)
        {

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
           
            if (curDistance < distance && curDistance!=0)
            {
               
                closest = go;
                distance = curDistance;
                Target = closest.gameObject;
                anterior = closest.gameObject;
             
            }

        }

    }



    void navhunt()
    {




        Vector3 direction = Target.transform.position - transform.position;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();


        anim.SetFloat("Horizontal", direction.x); // controla as animações
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", direction.magnitude);




        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - 0), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
      

    }

        void MoveCharacter(Vector3 frameMovement)
        {
            transform.position += frameMovement;
        }


     


    


    private  void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
             BuscaInimigo2();
             Target.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);

           

        }


    }
        public void Delete(float time)
        {
       float timeDestroy = time;
        Destroy(gameObject, timeDestroy);
        }

}



