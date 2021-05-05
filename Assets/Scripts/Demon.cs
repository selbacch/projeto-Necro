using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{

    private float timeDestroy;

    // Start is called before the first frame update
    void Start()
    {
       
            gameObject.GetComponent<Rigidbody>();
        Delete();
     
    }

    // Update is called once per frame
    void Update()
    {
        atropelar();
    }


    void atropelar()// faz ele caminhar para baixo 
    {

        transform.position += Vector3.down * Time.deltaTime;
    }



    public void Delete()
    {
        timeDestroy = 5f;
        Destroy(gameObject, timeDestroy);
    }




}
