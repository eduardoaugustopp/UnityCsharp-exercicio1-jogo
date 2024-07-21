using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemGameOver;
    private Nave nave;
    private Pontuacao pontuacao;

    private void Start()
    {
        this.nave = GameObject.FindObjectOfType<Nave>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }
    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        //habilitar a imagem de Game Over
        this.imagemGameOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        this.imagemGameOver.SetActive(false);
        Time.timeScale = 1;
        this.nave.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.Reiniciar();

    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }

}
