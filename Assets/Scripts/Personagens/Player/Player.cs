using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

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
    public GameObject ZArcher;
    public Transform point;
    public bool atacando;
    public int combo1;
    public Vector3 move;
    public Rigidbody2D rig;
    public ItemInterface.Item MascaraEquipada;
    public bool ImmortalMode;
    public AttackZone attackCollider;


    // Start is called before the first frame update
    void Start()
    {
        this.MascaraEquipada = ItemInterface.Item.None;
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rig = GetComponent<Rigidbody2D>();
     //   NormalStatus();
    }


    // Update is called once per frame
    void Update()
    {
        
        if (!Death && !ImmortalMode && this.Vida.CurHealth < 1)
        {
            MortePlayer();
            return;
        }
        Mover();

    }

    private void MortePlayer()
    {
        Debug.Log("morte player");
        Death = true;
        DeathEvent?.Invoke();
    }

    public void OnHabilidade1(InputValue value)//void SumonFantasma()
    {
        if (gameObject.GetComponent<Mana>().CurMana < 1 || Death)
        {
            return;
        }
        anim.SetBool("sumon", true);
        GameObject FantasmaC = Instantiate(Fantasma, point.position, point.rotation, transform.parent);
        gameObject.GetComponent<Mana>().LostMana(1);

    }

    public void OnHabilidade3(InputValue value)//
    {
        if (gameObject.GetComponent<Mana>().CurMana < 2 || Death)
        { return; }

        // anim.SetTrigger("area");
        GetComponent<PlayerInput>().actions.Disable();
        this.transform.Find("PrisaoArea").gameObject.SetActive(true);
        gameObject.GetComponent<Mana>().LostMana(2);
        StartCoroutine(DesativaHabilidade3());
    }

    public void OnHabilidade2(InputValue value)//
    {
        if (gameObject.GetComponent<Mana>().CurMana < 1 || Death)
        { return; }

        anim.SetBool("sumon", true);
        GameObject ZombiC = Instantiate(Zombi, point.position, point.rotation, transform.parent);
        gameObject.GetComponent<Mana>().LostMana(1);


    }

    public void OnHabilidade4(InputValue value)//especcial mutavel
    {
        if (gameObject.GetComponent<Mana>().CurMana < 2 || Death)
        {
            return;
        }

        if (this.MascaraEquipada == ItemInterface.Item.None)
        {

            this.transform.Find("EspecialnoMask").gameObject.SetActive(true);

        }

        if (this.MascaraEquipada == ItemInterface.Item.MascaraUm)//sumona a assassina zumbi  com a lança(dano alto ) um arqueiro esquelto(atira flechas e fica perto do player ) e um cavaleiro putrifo(dano medio + -1 de veneno) 
        {
            anim.SetBool("sumon", true);

            GameObject Felipe = Instantiate(Zombi, point.position, point.rotation, transform.parent);
            //Felipe.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("controller felipe") as RuntimeAnimatorController;
            GameObject Winie = Instantiate(Zombi, point.position, point.rotation, transform.parent);
            GameObject Cassiano = Instantiate(Zombi, point.position, point.rotation, transform.parent);

        }

        if (this.MascaraEquipada == ItemInterface.Item.MascaraDois)
        {

            anim.SetBool("sumon", true);
            GameObject DemonC = Instantiate(Demon, point.position, point.rotation, transform.parent);

        }

        if (this.MascaraEquipada == ItemInterface.Item.MascaraTres)
        {
            this.transform.Find("RetornoHabilidade4").gameObject.SetActive(true);
            DanoAtual = 40;
            speed = 4;
            Vida.SetMaxHealth(300);
            Mana.SetMaxMana(6);
            anim.speed = 2;
            StartCoroutine(DesativaEfeitoMascara());

        }
        gameObject.GetComponent<Mana>().LostMana(3);
        //mundo dos mortos inimigos em determinada area ficam paralizados  e tem parte da vida drenada e recupera a do jogador 

    }
    private void NormalStatus()
    {
        this.transform.Find("RetornoHabilidade4").gameObject.SetActive(false);
        DanoAtual = CenaController.Instance.infoSessao.danoAtual;
        speed = 2;
        Vida.SetMaxHealth(CenaController.Instance.infoSessao.vidaMax);
        Mana.SetMaxMana(CenaController.Instance.infoSessao.manaMax);
        anim.speed = 0.5f;
    }

    IEnumerator DesativaEfeitoMascara()
    {
        yield return new WaitForSeconds(10);
        NormalStatus();
    }

    public void OnAction(InputValue value)
    {

        GameObject Interaction = attackCollider.target;

        if (Interaction == null || Death)
        {
            return;
        }

        if (Interaction.tag == "Opn")
        {
            if (Interaction.GetComponent<InterativaAbstract>().Abra != false) { return; }
            Interaction.GetComponent<InterativaAbstract>().Abrir(true);
        }

        if (Interaction.tag == "Conversa")
        {

            if (Interaction.GetComponent<InterativaAbstract>().Fala != false) { return; }

            Interaction.GetComponent<InterativaAbstract>().Falar(true);
        }

        if (Interaction.tag == "Leitura")
        {
            if (Interaction.GetComponent<InterativaAbstract>().Lido != false) { return; }

            Interaction.GetComponent<InterativaAbstract>().Ler(true);
        }
    }

    IEnumerator DesativaHabilidade3() //desabilita a habilidade 3 e habilita novamente os controles
    {
        yield return new WaitForSeconds(4);
        GetComponent<PlayerInput>().actions.Enable();
        GetComponentInChildren<AprisionaEnemy>().gameObject.SetActive(false);
    }
    public void OnMovimento(InputValue value)//faz os movimentos de andar
    {
        if (Death)
        {
            return;
        }
        Vector2 val = value.Get<Vector2>(); // InputValue.get
        move = new Vector3(val.x, val.y, 0); // new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        float Horizontal = move.x;
        float Vertical = move.y;

        anim.SetFloat("Horizontal", Horizontal);
        anim.SetFloat("Vertical", Vertical);
        anim.SetFloat("speed", move.magnitude);

        //

        if (move.y > 0)
        {
            anim.SetInteger("Idle", 1);

        }
        if (move.y < 0) { anim.SetInteger("Idle", -1); }
        if (move.y > 0) { anim.SetInteger("Idle", 1); }

        if (move.x > 0)
        {
            anim.SetInteger("Idle", 2);
        }

        if (move.x < 0 && move.y < 0)
        {
            anim.SetInteger("Idle", -4);
        }
        if (move.x > 0 && move.y > 0)
        {
            anim.SetInteger("Idle", 3);
        }
        if (move.x < 0 && move.y > 0)
        {
            anim.SetInteger("Idle", -3);
        }
        if (move.x > 0 && move.y < 0)
        {
            anim.SetInteger("Idle", 4);
        }
        if (move.x < 0)
        {
            anim.SetInteger("Idle", -2);
        }



    }

    void Mover()
    {
        // transform.position = transform.position + (move * speed * Time.deltaTime);
        rig.velocity = move * speed;
    }

    public void OnAtaque(InputValue value)
    {
        if (Death)
        {
            return;
        }
        atacando = true;
        anim.SetTrigger("" + combo1);
    }

    void sumonsop()//para animação de invocar
    {
        anim.SetBool("sumon", false);
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
        if (Death)
        {
            return;
        }

        List<GameObject> obs = attackCollider.ObterTargetsValidos();

        foreach (GameObject inimigo in obs)
        {
            if (inimigo != null && inimigo.tag == "Enemy")
            {
               inimigo.GetComponent<Enemy>().SofrerDano(DanoAtual);
            }
            
        }
    }

    void sting()
    {
        List<GameObject> obs = attackCollider.ObterTargetsValidos();

        foreach (GameObject inimigo in obs)
        {
            if (inimigo != null && inimigo.tag == "Enemy")
            {
                inimigo.GetComponent<Rigidbody2D>().AddForce(move * 1);
            }
            
        }

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

    public ItemInterface.Item EquiparMascara(ItemInterface.Item tipomascara)
    {
        if (Death)
        {
            return ItemInterface.Item.None;
        }
        ItemInterface.Item mascaraAnterior = this.MascaraEquipada;
        this.MascaraEquipada = tipomascara;

        return mascaraAnterior;
    }





}


