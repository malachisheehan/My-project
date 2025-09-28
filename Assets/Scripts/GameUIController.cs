using UnityEngine;
using TMPro;


public class GameUIController : MonoBehaviour
{
    public ScoreTextController scoreTextPlayer1, scoreTextPlayer2;
    public GameObject gameMenu;
    public BallController ball;
    public TextMeshProUGUI winText;



    private void OnStart()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreBoard;
        GameManager.Instance.OnWin += HandleWin;
    }

    private void OnDetroy()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScoreBoard;
        GameManager.Instance.OnWin -= HandleWin;
    }

     public void UpdateScoreBoard(int scoreOfPlayer1, int scoreOfPlayer2)
    {
        Debug.Log($"Updating score ui: {scoreOfPlayer1}-{scoreOfPlayer2}");
        scoreTextPlayer1.SetScore(scoreOfPlayer1);
        scoreTextPlayer2.SetScore(scoreOfPlayer2);
    }

    public void OnStartButtonClick()
    {
        gameMenu.SetActive(false);
        ball.Serve();
    }

    public void HandleWin(int winnerId)
    {
        gameMenu.SetActive(true);
        winText.text = $"Player {winnerId} wins!";
    }

}
