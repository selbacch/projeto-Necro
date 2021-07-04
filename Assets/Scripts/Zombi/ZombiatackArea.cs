using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiatackArea : MonoBehaviour
{
    public static Action EnemyEmAttack;
    public static Action EnemyEntrouAttack;
    public static Action EnemySaiuAttack;
    public Collider2D coll;



    void Start()
    {

    }

    void Update()
    {
        OnTriggerEnter2D(coll);
        OnTriggerExit2D(coll);
        OnTriggerStay2D(coll);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("?");
            gameObject.GetComponent<Zombi>().EnemyEntrouAttackArea();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<Zombi>().EnemySaiuAttackArea();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<Zombi>().EnemyEntrouAttackArea();
        }


    }
}


