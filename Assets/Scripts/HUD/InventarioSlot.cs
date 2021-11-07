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
    public GameObject mascaraDoisPrefab;
    public GameObject mascaraTresPrefab;
    public Image imgItem;
    public TMP_Text quantidade;
    public Button botao;
    public bool equipado;
    public AudioSource UseItem;
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
                prefab = this.mascaraUmPrefab;
                break;
            case ItemInterface.Item.MascaraDois:
                prefab = this.mascaraDoisPrefab;
                break;
            case ItemInterface.Item.MascaraTres:
                prefab = this.mascaraTresPrefab;
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
            imgItem.type = Image.Type.Simple;
            imgItem.preserveAspect = true;
            imgItem.enabled = true;
            UseItem.clip = prefab.GetComponent<ItemInterface>().audioColetarUtilizar.clip;
            if (qnt> 1)
            {
                this.quantidade.text = qnt.ToString();
            }
           
        }
        else
        {
            itemNoSlotInterface = null;
            imgItem.sprite = null;
            imgItem.color = new Color(0, 0, 0, 0);
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
        UseItem.Play();
    }

}
