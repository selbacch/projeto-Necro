using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Relampago : MonoBehaviour
{

    public Light2D Light;
    public Light2D Light2;
    // Start is called before the first frame update


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        StartCoroutine(FeedbackAnimation());



    }

    private IEnumerator FeedbackAnimation()
    {
        yield return new WaitForSeconds(1f);
        Light.intensity = 8.04f;
        Light.intensity = 8.04f;
    }



}
