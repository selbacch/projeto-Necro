using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEggs : MonoBehaviour
{
    public GameObject Filhotes;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.gameObject.GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chocar()
    {
        GameObject spider = Instantiate(Filhotes, transform.position, transform.rotation, transform.parent);
        GameObject spider2 = Instantiate(Filhotes, transform.position, transform.rotation, transform.parent);
        GameObject sipider3 = Instantiate(Filhotes, transform.position, transform.rotation, transform.parent);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            anim.SetBool("choca", true);
        }
    }




}
