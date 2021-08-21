using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;
    public GameManager _gameManager;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            scoreManager.RemoveScore();
            scoreManager.AddScore(new Score(_gameManager.Name, _gameManager.ScorePlayer));

            var _scores = scoreManager.GetHighScores().ToArray();
            for (int i = 0; i < _scores.Length; i++)
            {
                var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
                row._rank.text = (i + 1).ToString();
                row._name.text = _scores[i]._name;
                row._score.text = _scores[i]._score.ToString();
            }
        }
        else
        {
            var scores = scoreManager.GetHighScores().ToArray();
            for (int i = 0; i < scores.Length; i++)
            {
                var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
                row._rank.text = (i + 1).ToString();
                row._name.text = scores[i]._name;
                row._score.text = scores[i]._score.ToString();
            }
        }
    }
}
