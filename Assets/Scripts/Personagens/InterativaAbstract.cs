using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterativaAbstract : MonoBehaviour
{
    public bool Abra=false;
    public bool Fala = false;
    public bool Lido = false;

    public abstract void Abrir(bool Abrir);
        public abstract void Falar(bool Falar);

        public abstract void Ler(bool Ler);


    }

  