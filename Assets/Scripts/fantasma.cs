using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasma : MonoBehaviour
{
    private float timeDestroy;
    public GameObject necro;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Delete()//destroi no final da animação
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }


}



