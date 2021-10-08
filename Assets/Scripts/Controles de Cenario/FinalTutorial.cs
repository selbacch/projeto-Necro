using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTutorial : MonoBehaviour
{
    public GameObject Raio1;
    public GameObject Raio2;
    public GameObject toco1;
    public GameObject tronco1;
    public GameObject tronco2;
    public GameObject toco2;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
  

    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Player")
        {
            bool caiu = true;
            Raio1.SetActive(true);
            Raio2.SetActive(true);
          
        
        toco1.SetActive(true);
        toco2.SetActive(true);
        tronco1.SetActive(false);
        tronco2.SetActive(false);


    }

    }








}
