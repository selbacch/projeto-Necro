using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrisionAtack : MonoBehaviour
{
    public GameObject temp;
    public int DanoAtual; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
        if (!temp.activeSelf)
        {
            float timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {

            other.GetComponent<InterfaceAtacavel>().SofrerDano(this.DanoAtual);

        }

    }
}
