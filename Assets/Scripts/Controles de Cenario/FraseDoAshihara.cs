using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FraseDoAshihara : MonoBehaviour
{
    public TMP_Text texto;
    public string frase;
    public float Time;
    public float TimeOut;
    private float timeScale;
    public MenuFaseController menu;
    // Start is called before the first frame update
    void Start()
    {
     

        StartCoroutine(Conversa());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Conversa()
    {
        yield return new WaitForSeconds(Time);




        menu.AbrirStatus();
        //texto.text = frase;

        StartCoroutine(Saida());







    }
    IEnumerator Saida()
    {
        yield return new WaitForSeconds(TimeOut);

        {



            gameObject.SetActive(false);





        }



    }



}
