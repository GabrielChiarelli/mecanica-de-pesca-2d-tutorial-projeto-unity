using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedidorDaBarraDePesca : MonoBehaviour
{
    public static MedidorDaBarraDePesca Instance;

    public bool estaNoVerde { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<AreaPermitidaDaBarraDePesca>() != null)
        {
            estaNoVerde = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<AreaPermitidaDaBarraDePesca>() != null)
        {
            estaNoVerde = false;
        }
    }
}
