using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{

    public static StageController Instance;
    private Dictionary<string, string> evento;
    private List<string> eventos;
    private HashSet<String> evt;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        evt = new HashSet<string>();

    }

    public bool AddEvt(String codigoEvento)
    {
        if (evt.Contains(codigoEvento))
        {
            return false;
        }
        evt.Add(codigoEvento);
        return true;
    }

    public void LimparEventos()
    {
        evt.Clear();
    }



}
