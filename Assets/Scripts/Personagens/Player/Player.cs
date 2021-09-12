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
    public bool mask1;
    public bool mask2;
    public bool mask3;
    public bool mask4;
    public bool NoMask;
    public bool Pmask1;
    public bool Pmask2;
    public bool Pmask3;
    public bool Pmask4;

    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        MaskControler();
        if (mask3 == false) { NormalStatus(); }
      
    }
    private void MaskControler()
    {
        if (mask1 == false && mask2 == false && mask3 == false && mask4 == false)
        {
            NoMask = true;
        }
        if(mask1 == true) { mask2 = false; mask3 = false; mask4 = false; NoMask = false; }
        if (mask2 == true) { mask1 = false; mask3 = false; mask4 = false; NoMask = false; }
        if (mask3 == true) { mask2 = false; mask1 = false; mask4 = false; NoMask = false; }
        if (mask4 == true) { mask2 = false; mask3 = false; mask1 = false; NoMask = false; }
        if (NoMask == true) { mask2 = false; mask3 = false; mask4 = false; mask1 = false; }
    } 

    public void OnHabilidade1(InputValue value)//void SumonFantasma()
    {
        if (gameObject.GetComponent<Mana>().curMana < 1)
        {
            return;
        }
        anim.SetBool("sumon", true);
        GameObject FantasmaC = Instantiate(Fantasma, point.position, point.rotation, transform.parent);
        gameObject.GetComponent<Mana>().LostMana(1);

    }

    public void OnHabilidade3(InputValue value)//
    {
        if (gameObject.GetComponent<Mana>().curMana < 2)
        { return; }
                anim.SetTrigger("area");
        GetComponent<PlayerInput>().actions.Disable();
        this.transform.Find("PrisaoArea").gameObject.SetActive(true);
        gameObject.GetComponent<Mana>().LostMana(2);
    }

    public void OnHabilidade2(InputValue value)//
    {
        if (gameObject.GetComponent<Mana>().curMana < 1)
        { return; }

        anim.SetBool("sumon", true);
        GameObject ZombiC = Instantiate(Zombi, point.position, point.rotation, transform.parent);
        gameObject.GetComponent<Mana>().LostMana(1);
        

    }

    public void OnHabilidade4(InputValue value)//especcial mutavel
    {

        if (NoMask == true && gameObject.GetComponent<Mana>().curMana > 2)
        {

            this.transform.Find("EspecialnoMask").gameObject.SetActive(true);
           
        }

        if (mask1 == true && gameObject.GetComponent<Mana>().curMana > 2)//sumona a assassina zumbi  com a lança(dano alto ) um arqueiro esquelto(atira flechas e fica perto do player ) e um cavaleiro putrifo(dano medio + -1 de veneno) 
        {
            anim.SetBool("sumon", true);
           
            GameObject Felipe = Instantiate(Zombi, point.position, point.rotation, transform.parent);
            //Felipe.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("controller felipe") as RuntimeAnimatorController;
            GameObject Winie = Instantiate(Zombi, point.position, point.rotation, transform.parent);
            GameObject Cassiano = Instantiate(Zombi, point.position, point.rotation, transform.parent);
            gameObject.GetComponent<Mana>().LostMana(3);
        }

        if (mask2 == true && gameObject.GetComponent<Mana>().curMana > 2)
        {
            
            anim.SetBool("sumon", true);
            GameObject DemonC = Instantiate(Demon, point.position, point.rotation, transform.parent);
            gameObject.GetComponent<Mana>().LostMana(3);
        }

        if (mask3 == true && gameObject.GetComponent<Mana>().curMana > 2)
        {
            this.transform.Find("RetornoHabilidade4").gameObject.SetActive(true);
            DanoAtual = 40;
            speed = 4;
            GetComponentInChildren<Health>().maxHealth = 300;
            GetComponentInChildren<Mana>().maxMana = 0;
            anim.speed = 2;
            gameObject.GetComponent<Mana>().LostMana(3);
        }
        else
        {
            NormalStatus();
        }
        if (mask4 == true && gameObject.GetComponent<Mana>().curMana > 2)
        { return; }
        //mundo dos mortos inimigos em determinada area ficam paralizados  e tem parte da vida drenada e recupera a do jogador 

    }
    private void NormalStatus()
    {
        this.transform.Find("RetornoHabilidade4").gameObject.SetActive(false);
        DanoAtual = 20;
        speed = 2;
        GetComponentInChildren<Health>().maxHealth = 100;
        GetComponentInChildren<Mana>().maxMana = 3;
        anim.speed = 0.5f;
    }

    public void OnAction(InputValue value)
    {

        GameObject Interaction = gameObject.GetComponent<AttackZone>().enemy;
        if (Interaction.tag == "Opn")
        {
            Interaction.GetComponent<InteFaceInterativa>().Abrir(true);
        }


        if(Interaction.tag =="Conversa") { }

        if(Interaction.tag == "Leitura") { }
    }


    public void DaArea() //desabilita a habilidade 3 e habilita novamente os controles
    {
        //anim.SetBool("area", false);
        GetComponent<PlayerInput>().actions.Enable();


        GetComponentInChildren<AprisionaEnemy>().gameObject.SetActive(false);
    }
    public void OnMovimento(InputValue value)//faz os movimentos de andar
    {
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
        if (move.y < 0) { anim.SetInteger("Idle", -1);  }
        if (move.y > 0) { anim.SetInteger("Idle", 1);  }

        if (move.x > 0)
        {
            anim.SetInteger("Idle", 2); 
        }

        if (move.x < 0 && move.y<0)
        {
            anim.SetInteger("Idle", -4); 
        }
        if (move.x > 0 && move.y > 0)
        {
            anim.SetInteger("Idle",3); 
        }
        if (move.x < 0 && move.y > 0)
        {
            anim.SetInteger("Idle",-3); 
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
        transform.position = transform.position + (move * speed * Time.deltaTime);
    }

    public void OnAtaque(InputValue value)
    {
        atacando = true;
        anim.SetTrigger("" + combo1);
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

        GameObject inimigo = gameObject.GetComponent<AttackZone>().enemy;
        if (inimigo == null)
        {
            return;
        }
        inimigo.GetComponent<Enemy2>().SofrerDano(DanoAtual);
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

