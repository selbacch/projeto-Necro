using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCTRlWalk : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip Walknull;
    public AudioClip WalkGrass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ah muleque");
            audioSource.clip = WalkGrass;
        }
        else { 
  
        
            audioSource.clip = Walknull;
        }
    }
}
