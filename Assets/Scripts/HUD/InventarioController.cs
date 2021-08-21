using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    public static InventarioController Instance;

    private Dictionary<ItemInterface.Item, int> itens;

    public TMP_Text textoItens;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        itens = new Dictionary<ItemInterface.Item, int> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdicionarAoInventario(ItemInterface.Item itemTipo)
    {
        if (itens.ContainsKey(itemTipo))
        {
            itens[itemTipo] += 1;
        }
        else
        {
            itens.Add(itemTipo, 1);
        }

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

    public void RenderizaInventario()
    {
        textoItens.text = "";
        StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<ItemInterface.Item, int> item in this.itens)
        {
            sb.AppendLine(item.Key.ToString()+" :: "+item.Value.ToString());
        }

        textoItens.text = sb.ToString();
    }

}
