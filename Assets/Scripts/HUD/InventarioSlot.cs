using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioSlot : MonoBehaviour
{
    public GameObject pocaoMpPrefab;
    public GameObject pocaoHPPrefab;
    public GameObject mascaraUmPrefab;

    public Image imgItem;
    public TMP_Text quantidade;
    public Button botao;

    public GameObject itemNoSlot;
    private ItemInterface itemNoSlotInterface;

    public static Action ItemUtilizado;

    private void Start()
    {
      
    }

    private void Update()
    {

    }

    public void RenderizaItem(ItemInterface.Item tipoItem, int qnt)
    {
        GameObject itemNoSlot = null;
        GameObject prefab = null;
        switch (tipoItem)
        {
            case ItemInterface.Item.PocaoHP:
                prefab = this.pocaoHPPrefab;
                break;
            case ItemInterface.Item.PocaoMP:
                prefab = this.pocaoMpPrefab;
                break;
            case ItemInterface.Item.MascaraUm:
                break;

            case ItemInterface.Item.None:
            default:
                break;
        }
        Destroy(itemNoSlot);

        this.quantidade.text = string.Empty;
        if (tipoItem != ItemInterface.Item.None)
        {
            
           // itemNoSlot = Instantiate(prefab, transform);
            itemNoSlotInterface = prefab.GetComponent<ItemInterface>();           
            imgItem.sprite = prefab.GetComponent<SpriteRenderer>().sprite;
            imgItem.color = Color.white;
            if (qnt> 1)
            {
                this.quantidade.text = qnt.ToString();
            }

        }
        else
        {
            imgItem.sprite = null;
            imgItem.color = Color.white;
        }
        

    }

    public void UtilizarItem()
    {
        if (this.itemNoSlotInterface == null)
        {
            return;
        }
        if (this.itemNoSlotInterface.tipoTipo == ItemInterface.Item.None)
        {
            return;
        }

        this.itemNoSlotInterface.Utilizar();
        ItemUtilizado?.Invoke();
    }

}
