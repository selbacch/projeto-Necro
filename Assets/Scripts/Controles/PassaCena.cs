using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassaCena : MonoBehaviour
{
    public string Cena;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void passar()
    {
        SceneManager.LoadScene(Cena);
    }
}
