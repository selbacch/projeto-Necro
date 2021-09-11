using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{


    public float Speed;
    private GameObject target;
    public int Dano;
    private Vector3 direct;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Atack();
    }



   void Atack()
    {
        

        direct.z = 0;
        

       direct.Normalize();

       




        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(direct.magnitude - 0), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direct);


    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }




    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
          
            direct = col.gameObject.transform.position - transform.position;

            Atack(); 
        }

        if (col.tag == "sumon")
        {
            direct = col.gameObject.transform.position - transform.position;
            Atack();
        }

    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject fireC = Instantiate(fire, gameObject.transform.position, col.gameObject.transform.rotation, transform.parent);
            Destroy(this.gameObject);
        }

        if (col.tag == "sumon")
        {
            GameObject fireC = Instantiate(fire, gameObject.transform.position, col.gameObject.transform.rotation, transform.parent);
            Destroy(this.gameObject);
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<InterfaceAtacavel>().SofrerDano(Dano);
        }

        if (collision.gameObject.tag == "sumon")
        {
            collision.gameObject.GetComponent<InterfaceAtacavel>().SofrerDano(Dano);
        }
    }


}
