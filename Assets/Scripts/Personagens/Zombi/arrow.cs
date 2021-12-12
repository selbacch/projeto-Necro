using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Vector3 direct;
    public GameObject aljava;
    public int Dano;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // direct = aljava.GetComponent<Zarcher>().Direct;
        transform.Translate(direct * 5f * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<InterfaceAtacavel>().SofrerDano(Dano);
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "sumon")
        {
            collision.gameObject.GetComponent<InterfaceAtacavel>().SofrerDano(Dano);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
