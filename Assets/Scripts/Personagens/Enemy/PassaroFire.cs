using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaroFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        delete(4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {


        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<InterfaceAtacavel>().SofrerDano(1);
        }

        if (col.gameObject.tag == "sumon")
        {
            col.gameObject.GetComponent<InterfaceAtacavel>().SofrerDano(1);
        }

    }

    void delete(float time)
    {
        
        Destroy(gameObject, time);
    }
}
