using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    int scoreOfPlayer1, scoreOfPlayer2 = 0;
    public GameUIController gameUI;
    int winScore = 4;

    public void SetScores(string zoneTag)
    {
        if (zoneTag == "LeftZone")
            scoreOfPlayer2++;
        if (zoneTag == "RightZone")
            scoreOfPlayer1++;
        gameUI.UpdateScoreBoard(scoreOfPlayer1, scoreOfPlayer2);
    }

    public bool CheckWin()
    {
        int winnerId = scoreOfPlayer1 == winScore ? 1 : scoreOfPlayer2 == winScore ? 2 : 0;
        if(winnerId != 0)
        {
            gameUI.OnWin(winnerId);
            return true;
        }
        return false;
    }
   
}
