using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascaraGenerica : ItemInterface
{
    private Player player;
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
       
        InventarioController.Instance.EquiparMascara(this.tipoTipo);

    }
}
