using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator anim;
    public float Speed;
    public Transform Target;
    public float TargetDistance = 5;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>();


    

    }

    // Update is called once per frame
    void Update()
    {
        hunt();
    }





    void hunt()
    {
        Vector3 direction = Target.position - transform.position;
        
        direction.z = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();

        // Mas se ja estiver perto demais, na verdade quero fugir.
        // Inverte a direção anterior.
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







        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }
}
