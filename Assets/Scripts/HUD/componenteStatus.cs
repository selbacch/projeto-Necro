using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class componenteStatus : MonoBehaviour
{
    //public Button Roupa1;
    //public Button Roupa2;
    //public Button Roupa3;
    public Button Mask1;
    public Button Mask2;
    public Button Mask3;
    public Button NoMask;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Mask1.onClick.AddListener(() => EquipMask1());
        Mask2.onClick.AddListener(() => EquipMask2());
        Mask3.onClick.AddListener(() => EquipMask3());
        NoMask.onClick.AddListener(() => DesquipMask());
    }

    // Update is called once per frame
    void Update()
    {
        MostraMask();
    }

    void MostraMask()
    {
        if(Player.GetComponent<Player>().Pmask1 == true)
        {
            Mask1.gameObject.SetActive(true) ;
        }
        else
        {
            Mask1.gameObject.SetActive(false);
        }
        if (Player.GetComponent<Player>().Pmask2 == true)
        {
            Mask2.gameObject.SetActive(true);
        }
        else
        {
            Mask2.gameObject.SetActive(false); 
        }
        if (Player.GetComponent<Player>().Pmask3 == true)
        {
            Mask3.gameObject.SetActive(true);
        }
        else
        {
            Mask3.gameObject.SetActive(false); 
        }
        


    }

   public void EquipMask1()
    {
        Player.GetComponent<Player>().mask1 =true;
    }

    public void EquipMask2()
    {
        Player.GetComponent<Player>().mask2 = true;
    }
    public void EquipMask3()
    {
        Player.GetComponent<Player>().mask3 = true;
    }
   public void DesquipMask()
    {
        Player.GetComponent<Player>().mask1 = false;
        Player.GetComponent<Player>().mask2 = false;
        Player.GetComponent<Player>().mask3 = false;
    }


}
