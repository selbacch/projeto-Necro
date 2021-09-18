using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterfaceAtacavel: MonoBehaviour
{
    public bool Death;
    public Action DeathEvent;
    public abstract void Atacar(int danoInflingido);
    public abstract void SofrerDano(int danoRecebido);

    public abstract int Dano();

    
}
