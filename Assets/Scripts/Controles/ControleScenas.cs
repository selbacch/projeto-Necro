using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleScenas : MonoBehaviour
{
    public string cena;
    public GameObject Player;
    public string CenaAtual;
    public bool Nomask = false;
    public bool mask1 = false;
    public bool mask2 = false;
    public bool mask3 = false;
    public bool mask4 = false;
    public bool checkB1 = false;
    public int Vida = 0;
    public int mana= 0;
    public Dictionary<ItemInterface.Item, int> itens;


    // Start is called before the first frame update
    void Start()
    {
        CenaAtual = SceneManager.GetActiveScene().name;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == cena)
        {
            ColocaValores();
            //Destroy(gameObject);
        }
    }

    void ColocaValores()
    {
        
            this.transform.Find("Player").gameObject.GetComponent<Player>().mask1 = mask1;
            this.transform.Find("Player").gameObject.GetComponent<Player>().mask2 = mask2;
            this.transform.Find("Player").gameObject.GetComponent<Player>().mask3 = mask3;
            this.transform.Find("Player").gameObject.GetComponent<Player>().mask4 = mask4;
            this.transform.Find("BAU_0").gameObject.GetComponent<Bau>().check = checkB1;
            this.transform.Find("Player").gameObject.GetComponent<Health>().curHealth = Vida;
            this.transform.Find("Player").gameObject.GetComponent<Mana>().curMana = mana;
            //this.transform.Find("Inventario").gameObject.GetComponent<InventarioController>().itens = itens;
    
      
        }
    void GuardaValores()
    {
      
            Nomask = Player.GetComponent<Player>().NoMask;
            mask1 = Player.GetComponent<Player>().mask1;
            mask2 = Player.GetComponent<Player>().mask2;
            mask3 = Player.GetComponent<Player>().mask3;
            mask4 = Player.GetComponent<Player>().mask4;

            Vida = Player.GetComponent<Health>().curHealth;
            mana = Player.GetComponent<Mana>().curMana;
            //itens = this.transform.Find("Canvas").GetComponentInChildren<InventarioController>().itens;
            checkB1 = this.transform.Find("BAU_0").gameObject.GetComponent<Bau>().check;
        
        



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Player = collision.gameObject;
            GuardaValores();
            DontDestroyOnLoad(gameObject);
           // SceneManager.LoadScene(cena);
        } 
    }
}
