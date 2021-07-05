using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : InterfaceAtacavel
{

    public Health Vida;
    public Mana Mana;
    public int DanoAtual;

    public Animator anim;
    public float speed;
    public GameObject Fantasma;
    public GameObject Demon;
    public GameObject Zombi;
    public Transform point;
    public bool atacando;
    public int combo1;
    public Vector3 move;
  

    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();

        if (Input.GetKeyDown(KeyCode.Q) && gameObject.GetComponent<Mana>().curMana > 0)
        {
            SumonFantasma();
            anim.SetBool("sumon", true);
        }
        if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<Mana>().curMana > 0)
        {
            anim.SetBool("sumon", true);
            SumonZombi();
        }
        if (Input.GetKeyDown(KeyCode.R) && gameObject.GetComponent<Mana>().curMana > 1)
        {
            anim.SetBool("sumon", true);
            SumonDemon();
        }
        combos();
    }

    void SumonFantasma()
    {
        GameObject FantasmaC = Instantiate(Fantasma, point.position, point.rotation) as GameObject; FantasmaC.transform.SetParent(point);
        gameObject.GetComponent<Mana>().LostMana(1);

    }

    void SumonDemon()
    {
        GameObject DemonC = Instantiate(Demon, point.position, point.rotation, transform.parent);

        gameObject.GetComponent<Mana>().LostMana(2);
    }

    void SumonZombi()
    {
        GameObject ZombiC = Instantiate(Zombi, point.position, point.rotation, transform.parent);
        gameObject.GetComponent<Mana>().LostMana(1);
    }

    void Moviment()//faz os movimentos de andar
    {
        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
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


    public void DandoDano()
    {
        //     GameObject inimigo = gameObject.GetComponent<AtackkZone>().enemy;

        //        inimigo.GetComponent<EnemyAI>().LevaDano(Dano);
    }

    public override void Atacar(int danoInflingido)
    {
        throw new System.NotImplementedException();
    }

    public override void SofrerDano(int danoRecebido)
    {
        this.Vida.DamagePlayer(danoRecebido);
       
    }

    public override int Dano()
    {
        return this.DanoAtual;
    }
}

