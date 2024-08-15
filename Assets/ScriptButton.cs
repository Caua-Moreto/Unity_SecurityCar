using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptButton : MonoBehaviour
{

    [SerializeField] private PerguntasManager perguntasManager;
    private Button _button;
    
    public bool isCorrect = false;

    private void Awake(){
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Clicado);
    }

    private void Clicado(){
        perguntasManager.Resposta(gameObject);
    }
        
}
