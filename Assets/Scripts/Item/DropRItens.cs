using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRItens : MonoBehaviour
{

    public GameObject[] dropitems;
    public GameObject dropitems2;
    private float droprate = 1;
    // Start is called before the first frame update


    public void DropObgItem()
    {
        
           
            Instantiate(dropitems2, this.transform.position, this.transform.rotation);
        
    }





public void DropRandItem()
    {
        if (dropitems.Length ==0)
        {
            return;
        }

        if (Random.Range(0, 2) <= droprate)
        {
            int indexToDrop = Random.Range(0, dropitems.Length);
            Instantiate(dropitems[indexToDrop], this.transform.position, this.transform.rotation);
        }
    }

}
