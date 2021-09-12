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
        if(Player.GetComponent<Player>().mask1 == true)
        {
            Indicador.sprite = mask1;
        }

       
        if (Player.GetComponent<Player>().mask2 == true)
        {
            Indicador.sprite = mask2;
        }
        if (Player.GetComponent<Player>().mask3 == true)
        {
            Indicador.sprite = mask3;
        }
        if (Player.GetComponent<Player>().NoMask == true)
        {
            Indicador.sprite = hipatia;
        }


    }





}
