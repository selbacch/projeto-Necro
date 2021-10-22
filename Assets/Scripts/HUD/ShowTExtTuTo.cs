using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTExtTuTo : MonoBehaviour
{
    public float time;
    public Text  texto;
    public string txt;
    public MenuFaseController menu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Ativa(time));
    }

    void Mtxt()
    {
        texto.text = txt;
    }

    IEnumerator Ativa(float Time)
    {
        yield return new WaitForSeconds(Time);
        GetComponent<EdgeCollider2D>().enabled = true;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Player")
        {
            
            menu.AbrirStatus();
            texto.text = txt;
          

        }

    }


}
