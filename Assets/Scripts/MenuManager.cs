#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       20/09/2017 12:44

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private Text winner;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text computerScore;

    private void Awake()
    {
        Button startButton = startMenu.GetComponentInChildren<Button>();
        Button restartButton = endMenu.GetComponentInChildren<Button>();

        startButton.onClick.AddListener(()=> StartGame());
        restartButton.onClick.AddListener(()=> StartGame());
    }

    private void StartGame()
    {
        gameObject.SetActive(false);
        GameManager.Instance.StartRound();
    }

    public void EndGame(int playerScore, int computerScore)
    {
        if (playerScore > computerScore)
        {
            winner.text = "Player won";
        }
        else
        {
            winner.text = "Computer won";
        }

        this.playerScore.text = playerScore.ToString();
        this.computerScore.text = computerScore.ToString();

        startMenu.SetActive(false);
        endMenu.SetActive(true);
        gameObject.SetActive(true);
    }
}
