using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public static Action PlayerEmAttack;
    public static Action PlayerEntrouAttack;
    public static Action PlayerSaiuAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag.Equals("Player"))
        {
           
            PlayerEntrouAttack?.Invoke();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerSaiuAttack?.Invoke();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerEmAttack?.Invoke();
        }

    }
}
