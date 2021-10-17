using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : InterativaAbstract
{
    private GameObject Player;
    public bool check = false;
    public MenuFaseController menu;
    public Text texto;
    public string[] txt;
    private int Dialogo;
    public GameObject ButtonAct;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public override void Abrir(bool Abrir)
    {
        throw new System.NotImplementedException();
    }
    public override void Ler(bool Ler)
    {
        throw new System.NotImplementedException();

    }
    public override void Falar(bool Falar)
    {
        if (Falar == true && Player.tag == "Player")
        {

            menu.AbrirStatus();
            if (txt.Length == 0)
                return;





            StartCoroutine(Conversa());
            





        }

    }
    void NextFala() { Dialogo = (Dialogo + 1) % txt.Length;
        texto.text = txt[Dialogo];
    }
    IEnumerator Conversa()
    {
        yield return new WaitForSeconds(2f);
        NextFala();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Player = collision.gameObject;
            ButtonAct.SetActive(true);
        }
        else
        {
            ButtonAct.SetActive(false);
        }

    }
}
