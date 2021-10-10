using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawContole : MonoBehaviour
{
    private GameObject[] gos;
    public GameObject[] points;
    public GameObject Enemy;
    public GameObject EnemyC;
    public GameObject Enemy3;

    private bool orda2 = false;
    public bool orda3;
    public bool MIniboss;
    // Start is called before the first frame update
    void Start()
    {

        if (points.Length == 0)
        {
            points = GameObject.FindGameObjectsWithTag("Respawn");
        }
        Enemyonda1();
    }

    // Update is called once per frame
    void Update()
    {
       
                




       
       
    }

    void Enemyonda1()
    {
        Debug.Log("hum...");
       
        GameObject closest = null;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length == 0)
        {
            
            for (int i = 0; i < points.Length; i++)
            {

                foreach (GameObject point in points)
                {
                    closest = point;
                    GameObject enemy = Instantiate(Enemy, point.transform.position, point.transform.rotation, transform.parent);



                }


            }
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            if (closest != null)
            {
                GameObject enemyc = Instantiate(EnemyC, closest.transform.position, closest.transform.rotation, transform.parent);
            }

        }

    }

    void Enemyonda2()
    {
        Debug.Log("hum2...");
        
        GameObject closest = null;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length == 0)
        {

            for (int i = 0; i < points.Length * 3; i++)
            {

                foreach (GameObject point in points)
                {
                    closest = point;
                    GameObject enemy = Instantiate(Enemy, point.transform.position, point.transform.rotation, transform.parent).GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");



                }

                
            }
            orda2 = true;
            
        }

    }


    void Enemyonda3()
    {
        Debug.Log("hum3...");
      
        GameObject closest = null;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length == 0)
        {

            for (int i = 0; i < points.Length * 3; i++)
            {

                foreach (GameObject point in points)
                {
                    closest = point;
                    GameObject enemy = Instantiate(Enemy, point.transform.position, point.transform.rotation, transform.parent).GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");
                    enemy.GetComponent<Enemy>().DanoAtual = +5;


                }


            }
            orda3 = false;
          
        }

    }

    void MiniBOss()
    {
        GameObject[] tos;
     
       
        if (os.Length == 0)
        {
            Debug.Log("hum boss...");
            GameObject[] gos;
            GameObject closest = null;
            gos = GameObject.FindGameObjectsWithTag("Respawn");
            float distance = Mathf.Infinity;
            Vector3 position = this.transform.Find("Player").gameObject.transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance && MIniboss == true)
                {

                    {


                        closest = go;
                        GameObject miNiBoss = Instantiate(Enemy3, closest.transform.position, closest.transform.rotation, transform.parent).GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");





                    }
                    MIniboss = false;
                }

            }
        }
    }
}





    

