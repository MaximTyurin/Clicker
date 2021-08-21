using System;

[Serializable]
public class Score
{
    public string _name;
    public int _score;

    public Score(string name, int score)
    {
        _name = name;
        _score = score;
    }
}
