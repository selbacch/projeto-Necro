using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnController : MonoBehaviour
{
    private GameObject[] gos;
    public GameObject[] points;
    public GameObject Enemy;
    public GameObject EnemyC;
    public GameObject MiNiBoss;
    public RuntimeAnimatorController SpriteEnemy;
    public RuntimeAnimatorController SpriteComander;
       public RuntimeAnimatorController SpriteMiniBoss;
    public Transform proxPlayer;

    public GameObject barreira;

    public bool orda2 = true;
    public bool orda3;
    public bool MIniboss;
    public bool Fim = false;
    // Start is called before the first frame update
    void Start()
    {

        if (points.Length == 0 && Fim  !=true)
        {
            points = GameObject.FindGameObjectsWithTag("Respawn");
        }
        Enemyonda1();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fim != true)
        {
            if (orda2 != false)
            {
                Enemyonda2();
            }

            if (orda2 == true && orda3 == true)
            {
                Enemyonda3();
            }

            if (orda3 == false && MIniboss == true)
            {
                MiniBOss();
            }

        }
        else
        {
            Destroy(barreira);
        }
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
                    enemy.GetComponent<Animator>().runtimeAnimatorController = SpriteEnemy;


                }


            }
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            if (closest != null)
            {
                GameObject enemyc = Instantiate(EnemyC, closest.transform.position, closest.transform.rotation, transform.parent);
                enemyc.GetComponent<Animator>().runtimeAnimatorController = SpriteComander;
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

            for (int i = 0; i < points.Length * 2; i++)
            {

                foreach (GameObject point in points)
                {
                    closest = point;
                    GameObject enemy = Instantiate(Enemy, point.transform.position, point.transform.rotation, transform.parent).GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");
                    enemy.GetComponent<Animator>().runtimeAnimatorController = SpriteEnemy;


                }

                
            }
            orda2 = true;

         
            
        }

    }


    void Enemyonda3()
    {
        
      
        GameObject closest = null;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length == 0)
        {
        orda3 = false;
            for (int i = 0; i < points.Length ; i++)
            {

                foreach (GameObject point in points)
                {
                 
                    closest = point;
                    GameObject enemy = Instantiate(Enemy, point.transform.position, point.transform.rotation, transform.parent).GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");
                    enemy.GetComponent<Enemy>().DanoAtual = +5;
                    enemy.GetComponent<Animator>().runtimeAnimatorController = SpriteEnemy;

                }

            }
            
         }

    }

    void MiniBOss()
    {

        gos = GameObject.FindGameObjectsWithTag("Enemy");

        if (gos.Length == 0)
        {





            GameObject miNiBoss = Instantiate(MiNiBoss, proxPlayer.position, proxPlayer.rotation);miNiBoss.GetComponent<Animator>().runtimeAnimatorController = SpriteMiniBoss;
            miNiBoss.GetComponent<Enemy>().Target = GameObject.FindGameObjectWithTag("Player");



            MIniboss = false;
            Fim = true;
        }    
    }
}





    

