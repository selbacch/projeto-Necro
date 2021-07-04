using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiagroarea : MonoBehaviour
{
    public static Action EnemyEmAggro;
    public static Action EnemyEntrouAggro;
    public static Action EnemySaiuAggro;
    public Collider2D coll;


    public void Update()
    {
        OnTriggerEnter2D(coll);
            OnTriggerExit2D(coll);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("??");
            gameObject.GetComponent<Zombi>().EnemyEntrouAggro();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<Zombi>().EnemySaiuAggro();

        }

          }


}

