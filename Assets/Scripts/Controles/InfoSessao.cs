using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class InfoSessao
{
    [SerializeField]
    private ItemInterface.Item mascaraEquipada;

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
    
    [SerializeField]
    private String inventario;
    [SerializeField]
    private Vector3 positionE;

    [SerializeField]
    private string Cena;
    public void SalvaStatusJogo()
    {
        Player pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        this.danoAtual = pl.DanoAtual;
        this.vidaMax = pl.Vida.MaxHealth;
        this.manaMax = pl.Mana.MaxMana;
        this.mascaraEquipada = pl.MascaraEquipada;
        this.inventario = InventarioController.Instance.ToJson();
        this.dataHoraGravacao = DateTime.Now;
        this.Cena = SceneManager.GetActiveScene().name;
        string info = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", info);

    }

    public void CarregarStatusJogo()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            String sJson = System.IO.File.ReadAllText(Application.persistentDataPath + "/save.json");
            InfoSessao info = JsonUtility.FromJson<InfoSessao>(sJson);

            this.danoAtual = info.danoAtual;
            this.vidaMax = info.vidaMax;
            this.manaMax = info.manaMax;
            this.mascaraEquipada = info.mascaraEquipada;
            this.inventario = info.inventario;
            this.dataHoraGravacao = info.dataHoraGravacao;
            SceneManager.LoadScene(Cena);

        }
    }
}
