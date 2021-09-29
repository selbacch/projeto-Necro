using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawContole : MonoBehaviour
{

    public GameObject[] points;
    public GameObject Enemy;
    public GameObject EnemyC;
    
    private bool orda2 =false;
    public bool orda3;

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
        if (orda2 != true)
        {
            Enemyonda2();
        }
        if (orda3 == true && orda2 == true)
        {
            Enemyonda3();
        }
    }

    void Enemyonda1()
    {
        Debug.Log("hum...");
        GameObject[] gos;
        GameObject closest = null;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length == 0)
        {
            Debug.Log("hum2...");
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
      
        GameObject[] gos;
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
        
        GameObject[] gos;
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



}





    

