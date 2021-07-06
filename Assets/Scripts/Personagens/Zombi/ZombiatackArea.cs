using System;
using UnityEngine;

public class ZombiatackArea : MonoBehaviour
{
    public Action<GameObject> EnemyEmAttack;
    public Action<GameObject> EnemyEntrouAttack;
    public Action<GameObject> EnemySaiuAttack;
    // public Collider2D coll;



    void Start()
    {

    }

    void Update()
    {
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            

            this.EnemyEntrouAttack?.Invoke(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Enemy"))
        {

            this.EnemySaiuAttack?.Invoke(collision.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {

            this.EnemyEmAttack?.Invoke(collision.gameObject);
        }

    }


}



