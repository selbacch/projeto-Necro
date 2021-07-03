using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entradaefect : MonoBehaviour
{
    public Material invisivel;
    public Material runa;
    public GameObject quadrado;
 

    // Start is called before the first frame update
   void Start()
    {
        
    }
     void Update()
    {
 
    
    
    }

    void entra()
    {
        quadrado.GetComponent<Renderer>().material = runa;
        
    }

    void sai()
    {
        quadrado.GetComponent<Renderer>().material = invisivel;
        gameObject.GetComponent<Zombi>().IA = true;
        quadrado.GetComponent<ParticleSystem>().Stop();
    }

}
