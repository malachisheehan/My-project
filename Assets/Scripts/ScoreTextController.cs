using UnityEngine;
using TMPro;

public class ScoreTextController : MonoBehaviour
{


    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        text.text = score.ToString();
    }
}
