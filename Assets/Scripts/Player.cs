using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour,Atacavel
{

    public Animator anim;
    public float speed;
    public GameObject Fantasma;
    public GameObject Demon;
    public GameObject Zombi;
    public Transform point;
    public bool atacando;
    public int combo1;


    public Int32 Vida = 500;
    public float Resfriamento = 2;
    //public Int32 RaioAtaque = 2.5;
    //public Int32 RaioPerigo = 5;
    public Int32 Velocidade = 1;
    public Int32 Dano = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moviment();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SumonFantasma();
            anim.SetBool("sumon", true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("sumon", true);
            SumonZombi();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("sumon", true);
            SumonDemon();
        }
        combos();
    }

    void SumonFantasma()
    {
        GameObject FantasmaC = Instantiate(Fantasma, point.position, point.rotation) as GameObject; FantasmaC.transform.SetParent(point);


    }

    void SumonDemon()
    {
        GameObject DemonC = Instantiate(Demon, point.position, point.rotation, transform.parent);


    }

    void SumonZombi()
    {
        GameObject ZombiC = Instantiate(Zombi, point.position, point.rotation, transform.parent);

    }

    void Moviment()//faz os movimentos de andar
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("speed", move.magnitude);

        transform.position = transform.position + move * speed * Time.deltaTime;
        if (move.y > 0)
        {
            anim.SetInteger("Idle", 1);
        }
        if (move.y < 0) { anim.SetInteger("Idle", -1); }

        if (move.x > 0)
        {
            anim.SetInteger("Idle", 2);
        }
        if (move.x < 0) { anim.SetInteger("Idle", -2); }

    }

    void sumonsop()//para animação de invocar
    {
        anim.SetBool("sumon", false);
    }

    void combos() //combo atack
    {
        if (Input.GetButtonDown("Fire1") && !atacando)
        {
            atacando = true;
            anim.SetTrigger("" + combo1);
        }
    }
    public void start_combo()
    {
        atacando = false;
        if (combo1 < 3)
        {
            combo1++;

        }
    }
    public void finish_anim()//para animação de ataque
    {
        atacando = false;
        combo1 = 0;
    }

    public void Atacar(Atacavel inimigo)
    {
        inimigo.SofrerDano(this);
    }

    public void CausarDano(Atacavel atacado)
    {
        throw new System.NotImplementedException();
    }

    public void SofrerDano(Atacavel atacante)
    {
        Vida -= atacante.DanoCausado();
        if (Vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int DanoCausado()
    {
        return this.Dano;
    }
}

