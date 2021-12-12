using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InventarioUIController : MonoBehaviour
{
    public static InventarioUIController Instance;
    public InventarioSlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        InventarioUIController.Instance = this;
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

        foreach (KeyValuePair<ItemInterface.Item, int> item in InventarioController.Instance.Itens)
        {
            sb.Append(item.Key.ToString() + " :: " + item.Value.ToString() + ';');
            this.slots[slotIndex++].RenderizaItem(item.Key, item.Value);

        }

        Debug.Log(sb.ToString());
    }

    public void AtualizaGUIInventarioOnUtilizacao()
    {
        RenderizaInventario();
    }


}
