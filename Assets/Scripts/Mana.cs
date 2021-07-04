using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public int curMana = 3;
    public int maxMana = 3;
    public ManaBar ManaBar;
    // Start is called before the first frame update
    void Start()
    {
        curMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
      

    }


    public void LostMana(int damage)
    {
        curMana -= damage;

        ManaBar.SetMana(damage);
    }


}
