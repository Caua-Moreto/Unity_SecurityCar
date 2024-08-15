using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //importando a biblioteca responsável pelo reset

public class GameManager : MonoBehaviour
{

    public PerguntasManager perguntasManager;
    
    public CarLogic car;

    public Transform playerPos;
    private Vector2 inicialDist;
    public Text distTxt;
    public int respostasCorretas;
    public string gameState;

    [SerializeField] private TextMeshProUGUI respostasTexto;
    [SerializeField] private TextMeshProUGUI distanciaTexto;
    [SerializeField] private GameObject perguntaCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject hudCanvas;

    private void Awake()
    {
        perguntasManager = GetComponent<PerguntasManager>();
        Play();
    }

    // Update is called once per frame

    private void Start()
    {
        inicialDist = playerPos.position;
    }

    void Update()
    {
        GameOverActive();
        CalculoDist();
        // switch(gameState){
        //     case "Play":
        //         break;
        //     case "Pergunta":
        //         break;
        //     case "GameOver":
        //         break;
        // }
    }

    void GameOverActive()
    {
        if(car.gasosa <= 0) // aqui foi criado uma verificação para que o gameover apareça logo após a finalização da gasolina
        {   // vai ser criado uma corotina onde vamo colocar um tempo para que o gameover apareça
            StartCoroutine(TimeGameOverActive());
            GameOver();
        }
        
    }

    // aqui foi criado um IEnumerator para definir o tempo que irá surgir o game over
    IEnumerator TimeGameOverActive()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverCanvas.SetActive(true);
    }

    // aqui foi criado a lógica pra resetar o jogo
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        Play();
    }

    // aqui foi criado a lógica pra sair do jogo
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    
    // vamos criar a lógica para os metros em cima da tela
    void CalculoDist()
    {
        Vector2 distancia = (Vector2)playerPos.position - inicialDist;

        if(distancia.x < 0)
        {
            distancia.x = 0; // faz com que o valor exibido nunca seja negativo
        }
        distTxt.text = distancia.x.ToString("F0") + "m"; 
        //o F0 garante que o número exibido seja inteiro
    }

    public void Play(){
        gameState="Play";
        hudCanvas.SetActive(true);
        perguntaCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }
    public void GameOver(){
        gameState="GameOver";
        hudCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        respostasTexto.text = respostasCorretas.ToString();
        distanciaTexto.text = distTxt.text;
    }
    public void Pergunta(){
        gameState="Pergunta";
        hudCanvas.SetActive(false);
        perguntaCanvas.SetActive(true);
        perguntasManager.CriarPergunta();
    }
}
