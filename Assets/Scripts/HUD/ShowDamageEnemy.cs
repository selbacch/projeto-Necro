

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShowDamageEnemy : MonoBehaviour {


    // Use this for initialization
    void Start() {
        
    }
 // Update is called once per frame
 void Update () {
        int j = gameObject.GetComponentInParent<Enemy2>().MdanoRecebido;


        GetComponent<Text>().text = j.ToString(); // Setamos aqui o valor que eh para ser mostrado

    }


   


}