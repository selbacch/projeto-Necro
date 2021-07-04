using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public static Action PlayerEmAttack;
    public static Action PlayerEntrouAttack;
    public static Action PlayerSaiuAttack;
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
        if (collision.gameObject.tag.Equals("sumon"))
        {

            gameObject.GetComponent<EnemyAI>().PlayerEntrouAttackArea();
        }
        if (collision.gameObject.tag.Equals("Player"))
        {

            gameObject.GetComponent<EnemyAI>().PlayerEntrouAttackArea();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        


        if (collision.gameObject.tag.Equals("sumon"))
        {
            gameObject.GetComponent<EnemyAI>().PlayerSaiuAttackArea();
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<EnemyAI>().PlayerSaiuAttackArea();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon"))
        {
            gameObject.GetComponent<EnemyAI>().PlayerEntrouAttackArea();
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<EnemyAI>().PlayerEntrouAttackArea();
        }

    }
}
