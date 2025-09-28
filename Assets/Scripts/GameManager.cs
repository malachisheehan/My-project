using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }


    public event Action<int, int> OnscoreChanged;
    public event Action<int> OnWin;
    int scoreOfPlayer1, scoreOfPlayer2 = 0;
    int winScore = 4;

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
    // public GameUIController gameUI;
    

    public void SetScores(string zoneTag)
    {
        if (zoneTag == "LeftZone")
            scoreOfPlayer2++;
        if (zoneTag == "RightZone")
            scoreOfPlayer1++;
        //gameUI.UpdateScoreBoard(scoreOfPlayer1, scoreOfPlayer2);
        OnscoreChanged?.Invoke(scoreOfPlayer1, scoreOfPlayer2);
    }

    public bool CheckWin()
    {
        int winnerId = scoreOfPlayer1 == winScore ? 1 : scoreOfPlayer2 == winScore ? 2 : 0;
        if(winnerId != 0)
        {
            //gameUI.OnWin(winnerId);
            OnWin?Invoke(winnerId);
            return true;
        }
        return false;
    }
   
}
