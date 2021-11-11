using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyCommander : Enemy
{

    public Animator anim;
    public bool Gritou = false;
    public bool isAttackingEnemy;
    private GameObject[] points;

    private int destPoint = 0;
    void Start()
    {
        ConfigStart();
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);// não apagar evita que objeto gire  para ficar de pé no nav mash
        points = GameObject.FindGameObjectsWithTag("Respawn");
    }

    private void OnDestroy()
    {
        Debug.Log("Inimigo: commander " + this.GetHashCode() + " destroy ");
        DeathEvent?.Invoke();

    }

    void Update()
    {

        //VoltarPosicaoInicial();
        if (Vida <= 0)
        {
            Death = true;
            Anim.SetBool("death", true);
            Target = null;

        }
        if (Target != null && Target.tag == "sumon" && Target.GetComponent<InterfaceAtacavel>().Death == true)
        {
            Target = null;
        }

        if (Target == null)
        {
            Target = this.AreaPerigo.ObterProximoTarget();
        }

        if (Target == null)
        {
            Patrulhar();
        }
        else
        {
            Cacar();
        }

    }

    void Patrulhar()
    {

        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].transform.position;
        Vector3 dis = points[destPoint].transform.position;
        float distance = 1.1f;

        float distObj = Vector3.Distance(transform.position, points[destPoint].transform.position);

        if (distObj <= distance)

        {

            NextPoint();
        }
        Anim.SetFloat("Horizontal", dis.x); // controla as animações
        Anim.SetFloat("Vertical", dis.y);
        Anim.SetFloat("Speed", dis.magnitude);

    }
    void NextPoint() { destPoint = (destPoint + 1) % points.Length; }

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    public void ScreamComander()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity; ;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && go.name != "Enemy Comander")
            {
                closest = go;
                distance = curDistance;
                closest.gameObject.GetComponent<Enemy>().Target = Target;
                Gritou = true;
                anim.SetBool("Grito", false);

            }

        }


    }

}