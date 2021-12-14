using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BossCenaController : MonoBehaviour
{

    public ObjetivoDestruirInimigos objetivo;
    public GameObject msgTermino;
    // Start is called before the first frame update
    void Start()
    {
        objetivo.ObjetivoConcluido += ObjetivoConcluido;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjetivoConcluido()
    {
        StartCoroutine(Encerramento());
    }

    
    public IEnumerator Encerramento()
    {
        GameObject go_player = GameObject.FindGameObjectWithTag("Player");
        Player player = go_player.GetComponent<Player>();
        PlayerInput playerInput = go_player.GetComponent<PlayerInput>();

        yield return new WaitForSecondsRealtime(2);
        playerInput.DeactivateInput();
        msgTermino.SetActive(true);
        yield return new WaitForSecondsRealtime(6);
        msgTermino.SetActive(false);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("IN_creditos");

    }
}
