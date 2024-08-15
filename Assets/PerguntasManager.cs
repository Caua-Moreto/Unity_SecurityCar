using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PerguntasManager : MonoBehaviour
{

    private GameManager gameManager;
    private List<Pergunta> listaPerguntas = new List<Pergunta>();

    [SerializeField] private CarLogic car;
    
    [SerializeField] private TextMeshProUGUI _pergunta;
    [SerializeField] private TextMeshProUGUI _a;
    [SerializeField] private TextMeshProUGUI _b;
    [SerializeField] private TextMeshProUGUI _c;
    [SerializeField] private TextMeshProUGUI _d;

    [SerializeField] private Button b_a;
    [SerializeField] private Button b_b;
    [SerializeField] private Button b_c;
    [SerializeField] private Button b_d;
    
    // Start is called before the first frame update

    private void Awake(){
        gameManager = GetComponent<GameManager>();
    }
    
    void Start()
    {
        Pergunta pergunta1 = new Pergunta();

        pergunta1.pergunta = "O condutor ao realizar uma ultrapassagem proibida sabe que poderá ser penalizado com:";
        pergunta1.a = "Uma multa";
        pergunta1.b = "O recolhimento da Carteira Nacional de Habilitação";
        pergunta1.c = "A remoção do veículo";
        pergunta1.d = "A cassação da CNH";
        pergunta1.resposta = "A";

        listaPerguntas.Add(pergunta1);

        Pergunta pergunta2 = new Pergunta();

        pergunta2.pergunta = "Quando um acidente ocorre pela má conservação do veículo, pode-se afirmar que o condutor:";
        pergunta2.a = "Foi ineficiente";
        pergunta2.b = "Foi negligente";
        pergunta2.c = "Foi imprudente";
        pergunta2.d = "Foi inábil";
        pergunta2.resposta = "B";

        listaPerguntas.Add(pergunta2);

        Pergunta pergunta3 = new Pergunta();

        pergunta3.pergunta = "É um dever do Estado, em relação ao trânsito:";
        pergunta3.a = "Viver em meio ambiente saudável e seguro";
        pergunta3.b = "Controlar a emissão de gases poluentes do veículo e de ruídos";
        pergunta3.c = "Ter asseguradas ações em defesa da vida";
        pergunta3.d = "Ter um trânsito ordeiro e sem violência";
        pergunta3.resposta = "B";

        listaPerguntas.Add(pergunta3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CriarPergunta(){
        int rand = Random.Range(0,listaPerguntas.Count);
        Debug.Log(listaPerguntas[rand].resposta);
        _pergunta.text = listaPerguntas[rand].pergunta;
        _a.text = listaPerguntas[rand].a;
        _b.text = listaPerguntas[rand].b;
        _c.text = listaPerguntas[rand].c;
        _d.text = listaPerguntas[rand].d;
        GameObject btn = GameObject.Find(listaPerguntas[rand].resposta);
        btn.GetComponent<ScriptButton>().isCorrect = true;
        
        listaPerguntas.RemoveAt(rand);
        // listaPerguntas.Sort();
    }

    public void Resposta(GameObject _go){
        if(_go.GetComponent<ScriptButton>().isCorrect){
            gameManager.Play();   
            car.gasosa = 1;
            _go.GetComponent<ScriptButton>().isCorrect = false;
            gameManager.respostasCorretas++;
        } else{
            gameManager.Play();   
        }
    }
}