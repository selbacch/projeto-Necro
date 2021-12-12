using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    [SerializeField]
    private Dictionary<ItemInterface.Item, int> itens;
        
    public Dictionary<ItemInterface.Item, int> Itens { get { return itens; } }
    public static InventarioController Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        itens = new Dictionary<ItemInterface.Item, int>();

    }
    void Start()
    {

        

    }


    // Update is called once per frame
    void Update()
    {

    }

    public int AdicionarAoInventario(ItemInterface.Item itemTipo)
    {
        if (itemTipo == ItemInterface.Item.None)
        {
            return 0;
        }

        //não adicionar mais de uma mascara do mesmo tipo ao inventario
        if (itens.ContainsKey(itemTipo) &&
            itemTipo != ItemInterface.Item.MascaraUm && itemTipo != ItemInterface.Item.MascaraDois && itemTipo != ItemInterface.Item.MascaraTres)
        {
            itens[itemTipo] += 1;
        }
        else if (!itens.ContainsKey(itemTipo))
        {
            itens.Add(itemTipo, 1);
        }
        return itens[itemTipo];
    }

    public void RemoverDoInventario(ItemInterface.Item itemTipo)
    {
        int qnt = 0;
        if (itens.TryGetValue(itemTipo, out qnt))
        {
            if (qnt > 1)
            {
                itens[itemTipo] -= 1;
            }
            else
            {
                itens.Remove(itemTipo);
            }

        }
    }

    public string ToJson()
    {
        if (this.itens == null)
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();

        foreach (KeyValuePair<ItemInterface.Item, int> item in this.itens)
        {
            sb.Append("{ item:" + ((int)item.Key) + ",qnt:" + item.Value.ToString() + "}");

        }

        string newjs = string.Join(",", sb);
        newjs = "[" + newjs + "]";
        return newjs;
    }

    public void FromJson(string sjson)
    {
        if (sjson == null)
        {
            return;
        }
        Dictionary<ItemInterface.Item, int> valores = new Dictionary<ItemInterface.Item, int>();

        string[] terms = sjson.Split('{');
        Regex rgItems = new Regex("item:([0-9]*)");
        Regex rgQnt = new Regex("qnt:([0-9]*)");

        Match mtI = null;
        Match mtQ = null;

        foreach (string s in terms)
        {
            if (s.Length < 5)
            {
                continue;
            }
            mtI = rgItems.Match(s);
            mtQ = rgQnt.Match(s);
            //GroupCollection gc = mt.Groups;
            // gc [1] valor do item

            ItemInterface.Item item = (ItemInterface.Item)Convert.ToInt32(mtI.Groups[1].Value);
            int qnt = Convert.ToInt32(mtQ.Groups[1].Value);
            valores.Add(item, qnt);

        }

        this.itens = valores;

    }

}
