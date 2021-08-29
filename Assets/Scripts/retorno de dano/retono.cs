using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class retono : MonoBehaviour
{
    public Text dano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int danoso = GetComponent<Enemy2>().Vida - 100;
        dano.text = danoso.ToString();
    }
}
