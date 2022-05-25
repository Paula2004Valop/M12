using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inTheGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    


    public GameState currentGameState = GameState.menu;
    // Start is called before the first frame update
    public static int puntuacio;

    void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        BackToMainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        ChangeGameState(GameState.inTheGame);
    }
    public void GameOver()
    {
        ChangeGameState(GameState.gameOver);
    }
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }


    void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //Haurà de mostrar el menu principal
        }
        else if (newGameState == GameState.inTheGame)
        {
            //Configurarem l'escena perquè mostri el joc en funcionament
        }
        else if (newGameState == GameState.gameOver)
        {
            //Mostrarem la pantalla de fi de partida
        }

        currentGameState = newGameState;
    }
}
