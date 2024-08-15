using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLogic : MonoBehaviour
{

    private int direction;

    public float gasosa;
    public float gastoGasosa;

    public Image fill;

    public float speed;
    public float carSpeed;
    public float inputMove;
    public Rigidbody2D tireFront;
    public Rigidbody2D tireBack; 
    public Rigidbody2D carRb2d;

    [SerializeField] private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameState == "Play"){
            GetInput();
            fill.fillAmount = gasosa;
            tireFront.constraints = RigidbodyConstraints2D.None;
            tireBack.constraints = RigidbodyConstraints2D.None;
            carRb2d.constraints = RigidbodyConstraints2D.None;

        }
        else{
            tireFront.constraints = RigidbodyConstraints2D.FreezeAll;
            tireBack.constraints = RigidbodyConstraints2D.FreezeAll;
            carRb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }

    // Aqui é chamdo o input de movimento
    void GetInput()
    {
        inputMove = Input.GetAxis("Horizontal");
    }

    // Aqui está a lógica da gasolina, consumo, etc
    private void FixedUpdate()
    {
        if(gameManager.gameState != "Play") return; 
        if(gasosa>0){
            MoveLogic();
            MoveMobile();
        }

        ConsumoLogic();
        
    }

    // Aqui é criado a lógica de movimentaçao para o computador e mobile
    void MoveLogic()
    {
        tireFront.AddTorque(-inputMove * speed * Time.fixedDeltaTime);
        tireBack.AddTorque(-inputMove * speed * Time.fixedDeltaTime);
        carRb2d.AddTorque(-inputMove * carSpeed * Time.fixedDeltaTime);
    }

    void MoveMobile(){
        tireFront.AddTorque(direction * speed * Time.deltaTime);
        tireBack.AddTorque(direction * speed * Time.deltaTime);
        carRb2d.AddTorque(direction * carSpeed * Time.deltaTime);
    }

    // Aqui é criado a lógica da movimentação 
    void ConsumoLogic(){
        gasosa -= gastoGasosa * Mathf.Abs(inputMove) * Time.fixedDeltaTime;
        gasosa -= gastoGasosa * Mathf.Abs(direction) * Time.deltaTime;
    }

    public void CarInputMobile(int dir){
        direction = dir;
    }

}
