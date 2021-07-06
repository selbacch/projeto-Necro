using System;
using System.Collections;
using UnityEngine;


public class SoulLife : MonoBehaviour
{

    public SoulArea AreaIdentifica;
    public SoulLibera AreaLibera;
    public int Nvida;
    
    // Start is called before the first frame update
    void Start()
    {
        AreaIdentifica.PlayerEntrouSoul += PlayerEntrouSoulArea;
        AreaLibera.PlayerEntrouLibera += PlayerEntrouLiberaArea;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hunt(GameObject life)
    {
       
        Vector3 direction = life.transform.position - transform.position;
        // direction.y = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();

  




        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = 10 * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - 5), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }


    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    void Libera(Transform life)
    {

       life.GetComponent<Health>().Increase(Nvida);
    }


    void PlayerEntrouSoulArea(GameObject go)
    {
        hunt(go);
    }

    void PlayerEntrouLiberaArea(GameObject go)
    {
        go.GetComponent<Health>().Increase(Nvida);
        float timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);


    }


}
