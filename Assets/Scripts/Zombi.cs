using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{

     public Animator anim;
    public float Speed;
    public Transform Target;
    public float TargetDistance ;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    private float timeDestroy;
   




    void Start()
    {
        
        if (Target == null)
           Target = GameObject.FindGameObjectWithTag("enemy").transform; // coloca o inimigo como alvo 

        
        Delete();

    }

    void Update()
    {
        hunt();
        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("enemy").transform;

    }




    void hunt()   // caça o inimigo
    {
        Vector3 direction = Target.position - transform.position;

        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();

        
        if (distanceToTarget < TargetDistance)
        {
            direction = -direction;

        }
        anim.SetFloat("Horizontal", direction.x); // controla as animações
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("speed", direction.magnitude);

        if (distanceToTarget == TargetDistance)
        {
            if (direction.y > 0)
            {
                anim.SetInteger("Idle", 1);
            }
            if (direction.y < 0) { anim.SetInteger("Idle", -1); }

            if (direction.x > 0)
            {
                anim.SetInteger("Idle", 2);
            }
            if (direction.x < 0) { anim.SetInteger("Idle", -2); }
        }






        
        float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }


    public void Delete() //destroi apos 10
    {
        timeDestroy = 10f;
        Destroy(gameObject, timeDestroy);
    }



}