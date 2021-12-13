using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerHabilidade4Effect : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GetComponentInParent<Player>().move;


        Anim.SetFloat("Horizontal", direction.x);
        Anim.SetFloat("Vertical", direction.y);


    }
}
