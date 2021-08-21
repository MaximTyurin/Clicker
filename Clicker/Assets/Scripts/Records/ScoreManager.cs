using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData _sd;

    private void Awake()
    {
        var json = PlayerPrefs.GetString("_scores", "{}");
        _sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return _sd._scores.OrderByDescending(x => x._score);
    }

    public void AddScore(Score score)
    {
        _sd._scores.Add(score);
    }

    public void RemoveScore()
    {
        if (_sd._scores.Count > 7)
            _sd._scores.Remove(_sd._scores[0]);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(_sd);
        PlayerPrefs.SetString("_scores", json);
    }
}
