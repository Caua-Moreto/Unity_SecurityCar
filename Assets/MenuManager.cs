using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject loginCanvas;
        public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    // aqui foi criado a lógica pra sair do jogo
    public void Quit()
    {
        Application.Quit();
    }

    public void BotaoLogin()
    {
        loginCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
