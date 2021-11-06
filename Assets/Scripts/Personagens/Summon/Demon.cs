using UnityEngine;
using UnityEngine.AI;
public class Demon : Summon
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
      

        gameObject.transform.rotation = Quaternion.Euler(0,0,0);
;
        gameObject.GetComponent<Rigidbody>();
        Delete();


    }

    // Update is called once per frame
    void Update()
    {


    }




    void Atack()
    {

        pilar.gameObject.SetActive(true);
        
    }


    void StopAtack()
    {
        //fire.GetComponent<ParticleSystem>().Stop();


        pilar.gameObject.GetComponent<ParticleSystem>().Stop();

    }





    public void Delete()
    {
        timeDestroy = 7f;
        Destroy(gameObject, timeDestroy);
    }




}
