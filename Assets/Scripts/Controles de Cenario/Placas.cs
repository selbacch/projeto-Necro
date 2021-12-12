using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Placas : InterativaAbstract
{
    private GameObject Player;
    public bool check = false;
    public MenuFaseController menu;
    public TMP_Text texto;

    public string txt;
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
    public override void Falar(bool Falar)
    {
        throw new System.NotImplementedException();

    }
    public override void Ler(bool Ler)
    {
        if (Ler == true && Player.tag == "Player")
        {
           
            menu.AbriDialogo();
            texto.text = txt;

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