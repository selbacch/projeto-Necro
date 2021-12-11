using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwordStory : MonoBehaviour
{

    private string[] txt;
    private int Dialogo = 0;
    public TMP_Text texto;
    public float Time;
    public GameObject CaixaDialogo;

    private void Awake()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("Dialogos/SwordStory");
        txt = txtAsset.text.Split(';');
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator falas()
    {
        for (Dialogo = 0; Dialogo < txt.Length; Dialogo++)
        {
            texto.text = txt[Dialogo];
            yield return new WaitForSecondsRealtime(Time);
        }
    }


    void off()
    {
        CaixaDialogo.SetActive(false);
    }

    public void Skip()
    {
        SceneManager.LoadScene("FS_TUTORIAL");
    }

}
