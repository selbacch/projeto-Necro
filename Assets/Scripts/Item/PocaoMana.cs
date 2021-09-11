using UnityEngine;

public class PocaoMana : ItemInterface
{
    public GameObject Player;
    public int mana;
    private void Awake()
    {
        base.tipoTipo = Item.PocaoMP;
    }

    // Start is called before the first frame update
    void Start()
    {      
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Utilizar()
    {
        InventarioController.Instance.RemoverDoInventario(this.tipoTipo);
        Player.GetComponent<Mana>().PlusMana(mana);


    }




}
