using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class InfoSessao
{
    [SerializeField]
    private ItemInterface.Item mascaraEquipada;

    [SerializeField]
    private Dictionary<ItemInterface.Item, int> inventario;

    [SerializeField]
    private int manaMax;

    [SerializeField]
    private int vidaMax;

    [SerializeField]
    private int danoAtual;

    [SerializeField]
    private string infoCena;

    [SerializeField]
    private DateTime dataHoraGravacao;

    public void SalvaStatusJogo()
    {
        Player pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        this.danoAtual = pl.DanoAtual;
        this.vidaMax = pl.Vida.MaxHealth;
        this.manaMax = pl.Mana.MaxMana;
        this.mascaraEquipada = pl.MascaraEquipada;
        this.inventario = InventarioController.Instance.Itens;
        this.dataHoraGravacao = DateTime.Now;
        string info = JsonConvert.SerializeObject(this);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", info);
    }
}
