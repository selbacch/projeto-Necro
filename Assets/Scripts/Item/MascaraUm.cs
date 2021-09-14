using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascaraUm : ItemInterface
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        base.tipoTipo = Item.MascaraUm;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Utilizar()
    {
        InventarioController.Instance.RemoverDoInventario(this.tipoTipo);
        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        player = pl.GetComponent<Player>();
        player.MascaraEquipada = this.tipoTipo;
    }
}
