using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bau : InterativaAbstract
{
    private GameObject Player;
    public bool check= false;
    public string bauId;
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
        if (!StageController.Instance.AddEvt("Bau_abrir_mascara"+ bauId))
        {
            return;
        }
        if (Abrir == true && Player.tag == "Player")
        {
            Abra = true;
            //anim.Setbool("aberto", true);
            item();
        }
    }
    public override void Falar(bool Falar)
    {
        throw new System.NotImplementedException();

    }
    public override void Ler (bool Ler)
    {
        throw new System.NotImplementedException();

    }


    void item()
    {
        GetComponentInChildren<DropRItens>().DropObgItem();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            Player = collision.gameObject;
            
        }

    }






}
