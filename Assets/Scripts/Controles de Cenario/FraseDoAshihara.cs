using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FraseDoAshihara : MonoBehaviour
{
    public TMP_Text texto;
    public string frase;
    private float timeScale;
    public MenuFaseController menu;
    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;
        




        Time.timeScale = this.timeScale;

        StartCoroutine(Conversa());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Conversa()
    {
        yield return new WaitForSeconds(7f);




        menu.AbrirStatus();
        texto.text = frase;

        StartCoroutine(Saida());







    }
    IEnumerator Saida()
    {
        yield return new WaitForSeconds(3f);

        {



            gameObject.SetActive(false);





        }



    }



}
