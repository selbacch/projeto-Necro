using UnityEngine;

public class PocaoVida : ItemInterface
{
    public GameObject Player;
    public int vida;
    private void Awake()
    {
        base.tipoTipo = Item.PocaoHP;
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
        Player.GetComponent<Health>().Increase(vida);


    }

}
