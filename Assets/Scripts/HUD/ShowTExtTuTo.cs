using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTExtTuTo : MonoBehaviour
{
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
        
    }

    void Mtxt()
    {
        texto.text = txt;
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
