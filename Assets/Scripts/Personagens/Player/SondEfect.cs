using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SondEfect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceWalk;
    public AudioClip Enemynull;
    public AudioClip EnemyVariation;
    public AudioClip EnemyVariation1;
    public AudioClip EnemyVariation2;
    public AudioClip StingSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tocar()
    {
        if (audioSource == null)
        {
            return;
        }
        audioSource.Play() ;
  
    }
    #region Movimento
    public void TocarWalk()
    {
        audioSourceWalk.Play();

    }
    #endregion

    #region Ataque
    public void NoEnemy()
    {
        audioSource.clip = Enemynull;
       
    }
    
    public void ComboAtack(int combo)
    {
        audioSource.clip = EnemyVariation;
        switch (combo)
        {
            case 0:
                //audioSource.clip = EnemyVariation;
                Debug.Log("snit");
                break;
            case 1:
                audioSource.clip = EnemyVariation1;
                break;
            case 2:
                audioSource.clip = EnemyVariation2;
                break;
        }
    }

    public void StingAtack()
    {
       
        audioSource.clip = StingSound;
        audioSource.Play();
    }

    #endregion
}
