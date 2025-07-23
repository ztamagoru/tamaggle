using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private AudioClip scoreSFX;

    private int _totalScore = 0;
    private int _tempScore = 0;
    private int _touchedPegs = 0;
    private bool _scoringInProgress = false;

    public int TotalScore => _totalScore;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    int _currentMultiplier = 1;

    public Action<int> multiplierChange;

    public int multiplier
    {
        get => _currentMultiplier;
        private set
        {
            if (_currentMultiplier == value) return;

            _currentMultiplier = value;
            Debug.Log($"Multiplier changed to: {_currentMultiplier}");
            multiplierChange?.Invoke(_currentMultiplier);
        }
    }

    private void Update()
    {
        UpdateMultiplier();
    }

    private void UpdateMultiplier()
    {
        int total = PegManager.instance.TotalOrangePegs;
        int remaining = PegManager.instance.CurrentOrangePegs;

        if (total == 0)
        {
            multiplier = 1;
            return;
        }

        float ratio = (float)remaining / total;

        if (ratio >= 0.8f)
            multiplier = 1;
        else if (ratio >= 0.6f)
            multiplier = 2;
        else if (ratio >= 0.4f)
            multiplier = 3;
        else if (ratio >= 0.2f)
            multiplier = 4;
        else
            multiplier = 5;
    }

    public void AddScore(int pegValue)
    {
        _tempScore += pegValue * multiplier;
        multiplierChange?.Invoke(multiplier);
        _touchedPegs++;
    }

    public async void CommitScoreAsync()
    {
        if (_scoringInProgress) return;

        _scoringInProgress = true;

        await Task.Delay(1000);

        int pointsToAdd = _tempScore * _touchedPegs;
        _totalScore += pointsToAdd;

        if (pointsToAdd >= 125000)
        {
            scoreSFX = Resources.Load<AudioClip>("SFX/extraball3");

            BallCounter.counter.AddBall();
            BallCounter.counter.AddBall();
            BallCounter.counter.AddBall();
        }
        else if (pointsToAdd >= 75000)
        {
            scoreSFX = Resources.Load<AudioClip>("SFX/extraball2");

            BallCounter.counter.AddBall();
            BallCounter.counter.AddBall();
        }
        else if (pointsToAdd >= 25000)
        {
            scoreSFX = Resources.Load<AudioClip>("SFX/extraball");

            BallCounter.counter.AddBall();
        }

        showScore(pointsToAdd);

        if (scoreSFX != null)
        {
            AudioSource.PlayClipAtPoint(scoreSFX, transform.position);
            scoreSFX = null;
        }

        _tempScore = 0;
        _touchedPegs = 0;
        _scoringInProgress = false;
    }

    private void showScore(int pointsToAdd)
    {
        Debug.Log($"Shoot Score: {pointsToAdd}. Total Score: {_totalScore}");
    }
}
