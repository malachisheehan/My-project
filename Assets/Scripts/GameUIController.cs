using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public ScoreTextController scoreTextPlayer1, scoreTextPlayer2;
    public GameObject gameMenu;
    public BallController ball;
    public TextMeshProUGUI winText;



    private void OnEnable()
    {
        GameManager.Instance.OnscoreChanged += UpdateScoreBoard;
        GameManager.Instance.OnWin += HandleWin;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnscoreChanged -= UpdateScoreBoard;
        GameManager.Instance.OnWin -= HandleWin;
    }

     public void UpdateScoreBoard(int scoreOfPlayer1, int scoreOfPlayer2)
    {
        scoreTextPlayer1.SetScore(scoreOfPlayer1);
        scoreTextPlayer2.SetScore(scoreOfPlayer2);
    }

    public void OnStartButtonClick()
    {
        gameMenu.SetActive(false);
        ball.Serve();
    }

    public void OnWin(int winnerId)
    {
        gameMenu.SetActive(true);
        winText.text = $"Player {winnerId} wins!";
    }

}
