using UnityEngine;

public class PocaoVida : ItemInterface
{
    public Health playerHealth;
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
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        InventarioController.Instance.RemoverDoInventario(this.tipoTipo);
        playerHealth.Increase(vida);
    }

}
