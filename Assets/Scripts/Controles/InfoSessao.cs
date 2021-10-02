using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class InfoSessao
{
    [SerializeField]
    private ItemInterface.Item mascaraEquipada;

    [SerializeField]
    private String inventario;

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
        this.inventario = JsonUtility.ToJson( InventarioController.Instance.Itens);
        this.dataHoraGravacao = DateTime.Now;

        string info = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", info);

    }

    public void CarregarStatusJogo()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            InfoSessao save = (InfoSessao)bf.Deserialize(file);
            file.Close();


        }
    }
}
