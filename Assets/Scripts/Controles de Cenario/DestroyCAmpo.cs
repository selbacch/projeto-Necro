using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCAmpo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       GameObject [] inimigos = GameObject.FindGameObjectsWithTag("Enemy");
        if (inimigos.Length ==0) {
            Destroy(gameObject, 0);
        
        
        }

    }
}
