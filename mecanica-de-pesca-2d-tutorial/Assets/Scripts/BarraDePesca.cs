using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDePesca : MonoBehaviour
{
    [Header("Movimento da BarraAzul")]
    [SerializeField] private GameObject barraAzul;
    [SerializeField] private float velocidadeDeMovimento = 2f;

    [Header("Caminho da BarraAzul")]
    [SerializeField] private Transform[] pontosDoCaminho;
    private int pontoAtual;

    private void Start()
    {
        pontoAtual = 0;
        barraAzul.transform.position = pontosDoCaminho[pontoAtual].position;
    }

    private void Update()
    {
        MovimentarBarraAzul();
    }

    private void MovimentarBarraAzul()
    {
        // Movimenta a BarraAzul até o próximo ponto.
        barraAzul.transform.position = Vector2.MoveTowards(barraAzul.transform.position, pontosDoCaminho[pontoAtual].position, velocidadeDeMovimento * Time.deltaTime);

        // Se a BarraAzul atingir o ponto alvo, se move para o próximo.
        if (barraAzul.transform.position == pontosDoCaminho[pontoAtual].position)
        {
            pontoAtual += 1;

            // Se a BarraAzul chegou ao último ponto disponível, retorna ao primeiro.
            if (pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }
}
