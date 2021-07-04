using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroArea : MonoBehaviour
{

    public static Action PlayerEmAggro;
    public static Action PlayerEntrouAggro;
    public static Action PlayerSaiuAggro;
    public Collider2D coll;



    void Start()
    {

    }

    void Update()
    {

        OnTriggerExit2D(coll);
        OnTriggerExit2D(coll);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon"))
        {
            gameObject.GetComponent<EnemyAI>().Target = collision.gameObject.transform;
            gameObject.GetComponent<EnemyAI>().PlayerEntrouAggro();
        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<EnemyAI>().Target = collision.gameObject.transform;
            gameObject.GetComponent<EnemyAI>().PlayerEntrouAggro();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon"))
        {

            gameObject.GetComponent<EnemyAI>().PlayerSaiuAggro();
        }
        if (collision.gameObject.tag.Equals("Player"))
        {

            gameObject.GetComponent<EnemyAI>().PlayerSaiuAggro();
        }

    }

    
}
