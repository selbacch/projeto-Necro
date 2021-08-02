using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    public static InventarioController Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdicionarAoInventario( ItemInterface.Item itemTipo)
    {

    }

    public void RemoverDoInventario(ItemInterface.Item itemTipo)
    {

    }
}
