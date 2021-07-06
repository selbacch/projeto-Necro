using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMana : MonoBehaviour
{

    public SoulArea AreaIdentifica;
    public SoulLibera AreaLibera;
    public int NMana;

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

        life.GetComponent<Mana>().PlusMana(NMana);
    }


    void PlayerEntrouSoulArea(GameObject go)
    {
        hunt(go);
    }

    void PlayerEntrouLiberaArea(GameObject go)
    {
        go.GetComponent<Mana>().PlusMana(NMana);
        float timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);


    }
}
