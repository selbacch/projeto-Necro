using UnityEngine;

public class PocaoVida : ItemInterface
{

    public int vida;
    private Health playerHealth;
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
        PlayAudio();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        InventarioController.Instance.RemoverDoInventario(this.tipoTipo);
        playerHealth.Increase(vida);
    }

}
