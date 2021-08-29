using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    public static InventarioController Instance;

    private Dictionary<ItemInterface.Item, int> itens;

    public InventarioSlot[] slots;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        itens = new Dictionary<ItemInterface.Item, int>();
        InventarioSlot.ItemUtilizado += AtualizaGUIInventarioOnUtilizacao;

    }

    private void OnDestroy()
    {
        InventarioSlot.ItemUtilizado -= AtualizaGUIInventarioOnUtilizacao;
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

    public void ResetaInventarioSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RenderizaItem(ItemInterface.Item.None, 0);
        }
    }

    public void RenderizaInventario()
    {

        StringBuilder sb = new StringBuilder();
        ResetaInventarioSlots();
        int slotIndex = 0;

        foreach (KeyValuePair<ItemInterface.Item, int> item in this.itens)
        {
            sb.Append(item.Key.ToString() + " :: " + item.Value.ToString()+';');
            this.slots[slotIndex++].RenderizaItem(item.Key, item.Value);

        }

        Debug.Log(sb.ToString());
    }


    public void AtualizaGUIInventarioOnUtilizacao()
    {
        RenderizaInventario();
    }

}
