using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroArea : MonoBehaviour
{

    public static Action PlayerEmAggro;
    public static Action PlayerEntrouAggro;
    public static Action PlayerSaiuAggro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(" entrou no aggro");
            PlayerEntrouAggro?.Invoke();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(" saiu no aggro");
            PlayerSaiuAggro?.Invoke();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(" está no aggro");
            PlayerEmAggro?.Invoke();
        }

    }
    

}
