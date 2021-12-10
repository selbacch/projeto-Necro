using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EffectEcho : MonoBehaviour
{
    public float TimeBtwSpawns;
    public float StartTimeSpawns;
    public GameObject Echo;
    public Animator Anim;
    public Vector3 Movement;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
 

         

        
        if (TimeBtwSpawns <= 0)
        {
            GameObject tracer= Instantiate(Echo, transform.position, Quaternion.identity);
            tracer.GetComponent<Animator>().SetFloat("Horizontal", Movement.x);
            tracer.GetComponent<Animator>().SetFloat("Vertical", Movement.y);
            TimeBtwSpawns = StartTimeSpawns;
          


        }
        else
        {
            TimeBtwSpawns -= Time.deltaTime;
           
        }
        



    }

    public void destroy()
    {
       
        Destroy(Echo);
    }




}

