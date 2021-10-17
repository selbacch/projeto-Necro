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
    private int Dialogo = 0;
    public GameObject ButtonAct;
    private float timeScale;
    public bool DropandDestroy;
    public GameObject Item;
    public GameObject Barreira;
    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;
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
            Fala = true;
            check = true;
            menu.AbrirStatus();
            if (txt.Length == 0)
                return;



            Time.timeScale = this.timeScale;
            
            StartCoroutine(Conversa());
           





        }

    }




    IEnumerator Conversa()
    {

        for (Dialogo = 0; Dialogo < txt.Length; Dialogo++)
        {
            texto.text = txt[Dialogo];
            yield return new WaitForSeconds(2f);
        }
        if (DropandDestroy != false)
        {
            Item.SetActive(true);
            Destroy(Barreira, 0);
            Destroy(this, 2);//Anim.SetBool("destroy",true);
        }
        else
        {
            Destroy(this, 2);//Anim.SetBool("destroy",true); }
        }
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
