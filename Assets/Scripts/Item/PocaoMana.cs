using UnityEngine;

public class PocaoMana : ItemInterface
{
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
        PlayAudio();
        InventarioController.Instance.RemoverDoInventario(this.tipoTipo);
        Mana manaComp = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        manaComp.Increase(mana);

    }




}
