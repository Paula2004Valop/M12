using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    LayerMask grundMask;

    [SerializeField]
    float JumpForce = 1.0f;

    [SerializeField]
    float RunningSpeed = 1.0f;

    [SerializeField]
    Animator animator;

    public Rigidbody2D rigitdboody2D;
    public Vector2 mover;
    private Vector2 cordenada;
    private Vector2 startPosition;
    public float vel;
    public object player;
    private Rigidbody2D rigidBody;
    private bool dreta = true;

    void Start()
    {
        rigitdboody2D = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);

        startPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("up")) {

            Jump();
        }
       
    

        if (Input.GetKeyDown(KeyCode.R))
         {
             if (GameManager.sharedInstance.currentGameState != GameState.inTheGame)
             {
                 Debug.Log("Restart");
                 StartGame();
             }

         }

         isOnTheFloor();
         kill();
         Moviment();
    }


    void Jump()
    {
        if(isOnTheFloor())
        {
           
            rigitdboody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            
        }
    }
    bool isOnTheFloor()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 5.0f, grundMask))
        {
            animator.SetBool("isGrounded", true);
            return true;
            
        }
        else
        {
            animator.SetBool("isGrounded", false);
            return false;
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "DeathZone")
        { 
            Debug.Log("HAS MORT");
            GameOver();
        }
        else if (collision.tag == "Fi")
        {
            Debug.Log("HAS GUANYAT");
            GameOver();
        }
        else if (collision.tag == "esp")
        {
          Debug.Log("Espasa");
            GameManager.puntuacio++;
            Debug.Log(GameManager.puntuacio);
        }
    }

    void kill()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("isGrounded", false);
            animator.SetBool("isAlive", false);

        }

        
    }
    void GameOver()
    {
        animator.SetBool("isGrounded", false);
        animator.SetBool("isAlive", false);
       GameManager.sharedInstance.currentGameState = GameState.gameOver;
    } 
    private void StartGame()
    {
        gameObject.transform.position = startPosition;
        animator.SetBool("isAlive", true);
        GameManager.sharedInstance.currentGameState = GameState.inTheGame;
    }
    void Moviment()
    {
        float inputMoviment = Input.GetAxis("Horizontal");
        

        rigidBody.velocity = new Vector2(inputMoviment * vel, rigidBody.velocity.y);
        Orentacio(inputMoviment);
    }
    void Orentacio(float inputMoviment)
    {
        if ((dreta == true && inputMoviment < 0) || (dreta == false && inputMoviment > 0))
        {
            dreta = !dreta;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
        

}
