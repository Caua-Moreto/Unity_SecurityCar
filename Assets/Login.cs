using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Http.Headers;
using Unity.VisualScripting;

public class Login : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;

    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField senha;

    private string emailString;
    private string senhaString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BotaoParaEntrarComUsuario()
    {
        emailString = email.text;
        senhaString = senha.text;
        menuCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
}
