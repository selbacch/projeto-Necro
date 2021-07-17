using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpinho : MonoBehaviour
{

    public GameObject SumonMorto;
    // Start is called before the first frame update
    private void Start()
    {
        
    }




    public void Delete() //fim da vida
    {
       float timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }
}
