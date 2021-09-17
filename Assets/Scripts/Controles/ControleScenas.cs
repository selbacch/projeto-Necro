using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControleScenas : MonoBehaviour
{
    public string cena;
    public GameObject Player;
    public string CenaAtual;
    public static ControleScenas instance;
    public ItemInterface.Item mascaraEquipada;
    public bool checkB1 = false;
    public int Vida = 0;
    public int mana = 0;
    public Dictionary<ItemInterface.Item, int> itens;
   
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {

            if (instance != this)
            {
                Debug.Log("INSTANCE ALREADY IN SCENE! LET'S DESTROY OURSELVES!");
                Destroy(this.gameObject);
            }

        }
    }
        void Start()
        {


            CenaAtual = SceneManager.GetActiveScene().name;

        }

        // Update is called once per frame
        void Update()
        {
            CenaAtual = SceneManager.GetActiveScene().name;
            if (SceneManager.GetActiveScene().name == cena)
            {

                ColocaValores();
                //Destroy(gameObject);
            }
        }

        void ColocaValores()
        {
            Player = GameObject.Find("Player").gameObject;
        
            if (SceneManager.GetActiveScene().name == "test2")
            {


                GameObject.Find("BAU_0").GetComponent<Bau>().check = checkB1;
                Player.gameObject.GetComponent<Health>().curHealth = Vida;
                Player.gameObject.GetComponent<Mana>().curMana = mana;
                Player.gameObject.GetComponent<Player>().MascaraEquipada = mascaraEquipada;
               // GameObject.Find("Canvas").GetComponentInChildren<InventarioController>().itens = itens;
            }
            if (SceneManager.GetActiveScene().name == "HOUSETST")
            {
                
                Player.gameObject.GetComponent<Health>().curHealth = Vida;
                Player.gameObject.GetComponent<Mana>().curMana = mana;
                Player.gameObject.GetComponent<Player>().MascaraEquipada = mascaraEquipada;
              //  GameObject.Find("Canvas").GetComponentInChildren<InventarioController>().itens = itens;
            }
        }
        void GuardaValores()
        {

        if (SceneManager.GetActiveScene().name == "test2")
        {
            mascaraEquipada = Player.gameObject.GetComponent<Player>().MascaraEquipada;
            Vida = Player.GetComponent<Health>().curHealth;
            mana = Player.GetComponent<Mana>().curMana;
            //itens =  GameObject.Find("Canvas").GetComponentInChildren<InventarioController>().itens;
             checkB1 = GameObject.Find("BAU_0").GetComponent<Bau>().check;
            
        }
        if (SceneManager.GetActiveScene().name == "HOUSETST")
        {

            mascaraEquipada = Player.gameObject.GetComponent<Player>().MascaraEquipada;
            Vida = Player.GetComponent<Health>().curHealth;
            mana = Player.GetComponent<Mana>().curMana;
        }
        }
        public void PlayerEntrouPortal(GameObject player,string Cena)
        {
            Player = player;
        cena = Cena;
        GuardaValores();
        SceneManager.LoadScene(cena);
      
            DontDestroyOnLoad(this.gameObject);

        }
      

    
}
