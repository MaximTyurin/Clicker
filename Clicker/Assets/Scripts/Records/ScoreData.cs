using System;
using System.Collections.Generic;

[Serializable]
public class ScoreData
{
    public List<Score> _scores;

    public ScoreData()
    {
        _scores = new List<Score>();
    }
}
