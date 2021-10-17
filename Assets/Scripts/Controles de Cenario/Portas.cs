using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : InterativaAbstract
{
    private GameObject Player;
    public bool check = false;
    private Animator Anim;
    public GameObject ButtonAct;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public override void Abrir(bool Abrir)
    {
        if (Abrir == true && Player.tag == "Player")
        {
            Anim.SetBool("aberto", true);

        }
    }
    public override void Falar(bool Falar)
    {
        throw new System.NotImplementedException();

    }
    public override void Ler(bool Ler)
    {
        throw new System.NotImplementedException();

    }

    IEnumerator FecharPorta()
    {

        yield return new WaitForSeconds(3f);
        Anim.SetBool("aberto", false);
    }
    void CallBackAnimation()
    {
        StartCoroutine(FecharPorta());
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