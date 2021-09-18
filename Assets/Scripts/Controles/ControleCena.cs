using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControleCena : MonoBehaviour
{
    public static ControleCena Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance)
        {
            Debug.Log("INSTANCE ALREADY IN SCENE! LET'S DESTROY OURSELVES!");
            Destroy(this.gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(this);
    }
    void Start()
    {


        //  CenaAtual = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
        //CenaAtual = SceneManager.GetActiveScene().name;
        //if (SceneManager.GetActiveScene().name == cena)
        //{


        //}
    }

    public void PlayerEntrouPortal(GameObject player, string Cena)
    {
        InfoSessao.Instance.SalvaValores();
        SceneManager.LoadScene(Cena);

    }



}
