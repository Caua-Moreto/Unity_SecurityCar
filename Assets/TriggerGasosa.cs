using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGasosa : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    

    // Aqui vai entrar a lógica de que depois de pega, a gasolina se autodetroi e some do jogo.
    private void OnTriggerEnter2D(Collider2D collision) {
        gameManager.Pergunta(); // Vai iniciar a fase de perguntas
        Destroy(gameObject);
        // gameManager.perguntasManager.CriarPergunta();
    }


}
