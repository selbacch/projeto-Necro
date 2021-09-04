using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AprisionaEnemy : MonoBehaviour
{

    public Transform Point;
    public GameObject Prisao;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     }






        void OnTriggerEnter2D(Collider2D collider)
    {
       
            
        
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("vim do chao");
            Point = collider.transform;
            GameObject JAULA = Instantiate(Prisao, Point.position, Point.rotation, transform.parent);
            JAULA.GetComponent<PrisionAtack>().temp = this.gameObject;
        }

    }


  

}
