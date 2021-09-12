using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleScenas : MonoBehaviour
{
    public string cena;
    private GameObject Player;
    private string CenaAtual;
    private bool Nomask = false;
    private bool mask1 = false;
    private bool mask2 = false;
    private bool mask3 = false;
    private bool mask4 = false;
    private bool checkB1 = false;
    private int Vida = 0;
    private int mana= 0;
    private InventarioSlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        CenaAtual = Application.loadedLevelName;
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.loadedLevelName == cena)
        {
            ColocaValores();
            
        }
    }

    void ColocaValores()
    {
        Player.GetComponent<Player>().mask1= mask1;
        Player.GetComponent<Player>().mask2= mask2 ;
        Player.GetComponent<Player>().mask3 = mask3;  
        Player.GetComponent<Player>().mask4=mask4;
        checkB1 = false;
         Player.GetComponent<Health>().curHealth= Vida;
        Player.GetComponent<Mana>().curMana = mana;
         GameObject.Find("Inventario").gameObject.GetComponent<InventarioController>().slots = slots;
         GameObject.Find("BAU_0").gameObject.GetComponent<Bau>().check = checkB1;
    }
    void GuardaValores()
    {
 Nomask = Player.GetComponent<Player>().NoMask;
     mask1 = Player.GetComponent<Player>().mask1;
     mask2 = Player.GetComponent<Player>().mask2;
     mask3 = Player.GetComponent<Player>().mask3;
    mask4 = Player.GetComponent<Player>().mask4;
     checkB1 = false;
     Vida = Player.GetComponent<Health>().curHealth;
    mana = Player.GetComponent<Mana>().curMana;
         slots = GameObject.Find("Inventario").gameObject.GetComponent<InventarioController>().slots;
        checkB1 = GameObject.Find("BAU_0").gameObject.GetComponent<Bau>().check;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Player = collision.gameObject;
            GuardaValores();
            DontDestroyOnLoad(gameObject);
            Application.LoadLevel(cena);
        } 
    }
}
