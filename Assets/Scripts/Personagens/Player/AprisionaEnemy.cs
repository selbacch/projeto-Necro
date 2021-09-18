using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AprisionaEnemy : MonoBehaviour
{

    public GameObject Prisao;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("vim do chao");
            Transform enemyPos = collider.transform;
            GameObject JAULA = Instantiate(Prisao, enemyPos.position, enemyPos.rotation, transform.parent);
            JAULA.GetComponent<PrisionAtack>().habilidadeGameobject = this.gameObject;
        }

    }

}
