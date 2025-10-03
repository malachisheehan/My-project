using UnityEngine;
using TMPro;


public class GameUIController : MonoBehaviour
{
    public ScoreTextController scoreTextPlayer1, scoreTextPlayer2;
    public GameObject gameMenu;
    public BallController ball;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playModeText;


    //subscibes to the actions when the program is started
    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreBoard;
        GameManager.Instance.OnWin += HandleWin;
        OnPlayModeButtonClicked();
    }

    //unsubscibes to the actions when the program is destroyed
    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScoreBoard;
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

    public void HandleWin(int winnerId)
    {
        gameMenu.SetActive(true);
        winText.text = $"Player {winnerId} wins!";
    }

    public void OnPlayModeButtonClicked()
    {
        switch (GameManager.Instance.playMode)
        {
            case GameManager.PlayMode.PlayerVsPlayer:
                GameManager.Instance.playMode = GameManager.PlayMode.PlayerVsCPU;
                playModeText.text = "Player Vs CPU";
                break;

            case GameManager.PlayMode.PlayerVsCPU:
                GameManager.Instance.playMode = GameManager.PlayMode.PlayerVsPlayer;
                playModeText.text = "Player Vs Player";
                break;
        }
    }

}
