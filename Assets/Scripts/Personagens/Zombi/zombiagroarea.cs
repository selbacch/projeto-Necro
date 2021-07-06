using System;
using UnityEngine;

public class zombiagroarea : MonoBehaviour
{
    public Action<GameObject> EnemyrEmAggro;
    public Action<GameObject> EnemyEntrouAggro;
    public Action<GameObject> EnemySaiuAggro;



    public void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            
            EnemyEntrouAggro?.Invoke(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            this.EnemySaiuAggro?.Invoke(collision.gameObject);
        }

    }


}

