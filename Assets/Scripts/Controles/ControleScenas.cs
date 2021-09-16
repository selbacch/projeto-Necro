using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleScenas : MonoBehaviour
{
    public string cena;
    public GameObject Player;
    public string CenaAtual;

    public ItemInterface.Item mascaraEquipada;
    public bool checkB1 = false;
    public int Vida = 0;
    public int mana = 0;
    public Dictionary<ItemInterface.Item, int> itens;


    // Start is called before the first frame update
    void Start()
    {
        CenaAtual = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == cena)
        {
          //  ColocaValores();
            //Destroy(gameObject);
        }
    }

    void ColocaValores()
    {
        //Player = this.transform.Find("Player").gameObject;

        //this.transform.Find("BAU_0").gameObject.GetComponent<Bau>().check = checkB1;
        //Player.gameObject.GetComponent<Health>().curHealth = Vida;
        //Player.gameObject.GetComponent<Mana>().curMana = mana;
        //Player.gameObject.GetComponent<Player>().MascaraEquipada = mascaraEquipada;
        //this.transform.Find("Inventario").gameObject.GetComponent<InventarioController>().itens = itens;


    }
    void GuardaValores()
    {
        //mascaraEquipada = Player.gameObject.GetComponent<Player>().MascaraEquipada;
      //  Vida = Player.GetComponent<Health>().curHealth;
       // mana = Player.GetComponent<Mana>().curMana;
        //itens = this.transform.Find("Canvas").GetComponentInChildren<InventarioController>().itens;
    //    checkB1 = this.transform.Find("BAU_0").gameObject.GetComponent<Bau>().check;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player = collision.gameObject;
            GuardaValores();
            DontDestroyOnLoad(gameObject);
            // SceneManager.LoadScene(cena);
        }
    }
}
