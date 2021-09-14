using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetornoMask : MonoBehaviour
{

    public GameObject Player;
    public Image Indicador;
    public Sprite mask1;
    public Sprite mask2;
    public Sprite mask3;
    public Sprite hipatia;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mask();
    }

    void mask()
    {
        switch (this.Player.GetComponent<Player>().MascaraEquipada)
        {
            case ItemInterface.Item.MascaraUm:
                Indicador.sprite = mask1;
                break;
            case ItemInterface.Item.MascaraDois:
                Indicador.sprite = mask2;
                break;
            case ItemInterface.Item.MascaraTres:
                Indicador.sprite = mask3;
                break;
            default:
                Indicador.sprite = hipatia;
                break;
        }

    }





}
