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
    IEnumerator raio()
    {
        yield return new WaitForSeconds(1.5f);
        Raio1.SetActive(false);
        Raio2.SetActive(false);


        toco1.SetActive(true);
        toco2.SetActive(true);
        tronco1.SetActive(false);
        tronco2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Player")
        {
            
            Raio1.SetActive(true);
            Raio2.SetActive(true);

            StartCoroutine(raio());



        }

    }








}
