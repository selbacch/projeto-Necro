using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhosSolo : MonoBehaviour
{
     Animator Anim;
    private GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SobeEspinhos()
    {
       yield return new WaitForSeconds(2);
        
        Debug.Log("snit");//Anim.SetTrigger("Ativa");
        Dano();
        
    }
    void Dano()
    {
        Player.GetComponent<InterfaceAtacavel>().SofrerDano(3);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Player = collision.gameObject;
            StartCoroutine(SobeEspinhos());
        }

    }
}
