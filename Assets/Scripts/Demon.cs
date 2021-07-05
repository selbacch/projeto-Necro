using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Demon : MonoBehaviour
{

    private float timeDestroy;
    public GameObject pilar;
    public ParticleSystem fire;


    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gameObject.GetComponent<Rigidbody>();
        Delete();
        
     
    }

    // Update is called once per frame
    void Update()
    {
      

    }


 

    void Atack()
    {

        pilar.gameObject.active = true;

     }

   
    void StopAtack()
    {
        fire.GetComponent<ParticleSystem>().Stop();


        pilar.gameObject.active = false;

    }

  

 

    public void Delete()
    {
        timeDestroy = 5f;
        Destroy(gameObject, timeDestroy);
    }




}
