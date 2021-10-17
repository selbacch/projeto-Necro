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
    public ItemInterface.Item mascaraEquipada { get; private set; }

    [SerializeField]
    public int manaMax { get; private set; }

    [SerializeField]
    public int vidaMax { get; private set; }

    [SerializeField]
    public int manaAtual { get; private set; }

    [SerializeField]
    public int vidaAtual { get; private set; }

    [SerializeField]
    public int danoAtual { get; private set; }

    [SerializeField]
    public string infoCena { get; private set; }

    [SerializeField]
    public DateTime dataHoraGravacao { get; private set; }

    [SerializeField]
    public String inventario { get; private set; }

    [SerializeField]
    public Vector3 positionE { get; private set; }

    [SerializeField]
    public string Cena { get; private set; }
    public void SalvaStatusJogo()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        if (go != null)
        {
            Player pl = go.GetComponent<Player>();
            this.danoAtual = pl.DanoAtual;
            this.vidaMax = pl.Vida.MaxHealth;
            this.manaMax = pl.Mana.MaxMana;
            this.mascaraEquipada = pl.MascaraEquipada;
            this.manaAtual = pl.Mana.CurMana;
            this.vidaAtual = pl.Vida.CurHealth;
        }

        if (InventarioController.Instance != null)
        {
            this.inventario = InventarioController.Instance.ToJson();
        }


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

            this.manaAtual = info.manaAtual;
            this.vidaAtual = info.vidaAtual;
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
