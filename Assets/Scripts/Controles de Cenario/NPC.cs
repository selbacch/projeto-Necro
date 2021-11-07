using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class NPC : InterativaAbstract
{
    private GameObject Player;
    public bool check = false;
    public MenuFaseController menu;
    public TMP_Text texto;
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

    IEnumerator Conversa()
    {
        Animator anima = GetComponent<Animator>();
        
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length == 0)
        {
            anima.SetBool("stop", true);
            Fala = true;
            check = true;
            for (Dialogo = 0; Dialogo < txt.Length; Dialogo++)
            {
                texto.text = txt[Dialogo];
                yield return new WaitForSecondsRealtime(2f);
            }
            if (DropandDestroy != false)
            {
                Item.SetActive(true);
                Destroy(Barreira, 0);
                Destroy(gameObject, 2);//Anim.SetBool("destroy",true);
            }
            else
            {
                Destroy(gameObject, 2);//Anim.SetBool("destroy",true); }
            }
        }
        else {
            string textinnho = "Derrote os inimigos porfavor eles não vão nos deixar sair total de inimigos :";
            texto.text = textinnho + Enemys.Length.ToString();
            Fala = false;
            check = false;
            Falar(false);
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
