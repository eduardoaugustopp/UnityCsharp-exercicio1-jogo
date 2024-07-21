using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.5f;
    [SerializeField]
    private float variacaoDaPosicaoY;
    private Vector3 posicaoDaNave;
    private Pontuacao pontuacao;
    private bool pontuei;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }

    private void Start()
    {
        this.posicaoDaNave = GameObject.FindObjectOfType<Nave>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void Update()
    {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);


        //Se a minha posicao for menor que a posicao do Nave
        if (!this.pontuei && this.transform.position.x < this.posicaoDaNave.x)
        {
            this.pontuei = true;
            this.pontuacao.AdicionarPontos();
        }

    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        this.Destruir();
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
