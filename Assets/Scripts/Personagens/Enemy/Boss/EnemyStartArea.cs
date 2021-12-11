using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyStartArea : MonoBehaviour
{

    public Action<GameObject> PlayerEntrouStartArea;
    public Action<GameObject> PlayerSaiuStartArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {

            this.PlayerEntrouStartArea?.Invoke(collision.gameObject);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {

            this.PlayerSaiuStartArea?.Invoke(collision.gameObject);

        }
    }

}
