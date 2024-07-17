using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDePesca : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private GameObject barraDePesca;

    [Header("Cronômetro da aparição dos peixes")]
    [SerializeField] private float tempoMaximoEntrePeixes = 3f;
    private float tempoAtualEntrePeixes;

    [Header("Cronômetro do peixe na vara")]
    [SerializeField] private float tempoMaximoParaPescar = 5f;
    private float tempoAtualParaPescar;

    private bool peixeNaVara = false;

    private void Start()
    {
        ResetarPesca();
    }

    private void Update()
    {
        if (!peixeNaVara)
        {
            RodarCronometroDoPeixe();
        }
        else
        {
            RodarCronometroDaPesca();
        }
    }

    private void RodarCronometroDoPeixe()
    {
        tempoAtualEntrePeixes -= Time.deltaTime;
        if (tempoAtualEntrePeixes <= 0)
        {
            peixeNaVara = true;
        }
    }

    private void RodarCronometroDaPesca()
    {
        tempoAtualParaPescar -= Time.deltaTime;
        if (tempoAtualParaPescar > 0)
        {
            barraDePesca.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                if (MedidorDaBarraDePesca.Instance.estaNoVerde)
                {
                    // Conseguiu pegar o peixe a tempo.
                    Debug.Log("Pegou o peixe :)");
                }
                else
                {
                    // Ainda tinha tempo, mas não acertou o medidor.
                    Debug.Log("Não pegou o peixe.");
                }

                ResetarPesca();
            }
        }
        else
        {
            // Acabou o tempo.
            Debug.Log("Acabou o tempo.");

            ResetarPesca();
        }
    }

    private void ResetarPesca()
    {
        peixeNaVara = false;
        tempoAtualEntrePeixes = tempoMaximoEntrePeixes;
        tempoAtualParaPescar = tempoMaximoParaPescar;

        barraDePesca.SetActive(false);
    }
}
