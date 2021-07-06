using System;
using UnityEngine;

public class SoulArea : MonoBehaviour
{
    public Action<GameObject> PlayerEntrouSoul;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {


            this.PlayerEntrouSoul?.Invoke(collision.gameObject);
        }

    }



}