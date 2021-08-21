using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInterface : MonoBehaviour
{
    public string Nome;
    public string Descricao;
    public Item tipoTipo;

    public enum Item { PocaoMP = 1001, PocaoHP = 1002, MascaraUm = 2001 }
    public virtual void Utilizar()
    {
        InventarioController.Instance.RemoverDoInventario(this.tipoTipo);
    }

    public virtual void Coletar()
    {
        InventarioController.Instance.AdicionarAoInventario(this.tipoTipo);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Coletar();
        }

    }

}
