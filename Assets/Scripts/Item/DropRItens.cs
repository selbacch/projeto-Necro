using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRItens : MonoBehaviour
{

    public GameObject[] dropitems;
    public GameObject dropitems2;
    private float droprate = 0.25f;
    // Start is called before the first frame update


    public void DropObgItem()
    {
        
           
            Instantiate(dropitems2, this.transform.position, this.transform.rotation);
        
    }





public void DropRandItem()
    {
        if (Random.Range(0, 1) <= droprate)
        {
            int indexToDrop = Random.Range(0, dropitems.Length);
            Instantiate(dropitems[indexToDrop], this.transform.position, this.transform.rotation);
        }
    }

}
