﻿#pragma warning disable 0649
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI facebookText;
    [SerializeField] private TextMeshProUGUI redditText;
    [SerializeField] private TextMeshProUGUI snapchatText;
    [SerializeField] private TextMeshProUGUI twitterText;

    private int[] scoreAmounts;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scoreAmounts = new []
        {
            UpgradeController.facebookScoreAmount,
            UpgradeController.redditScoreAmount,
            UpgradeController.snapchatScoreAmount,
            UpgradeController.twitterScoreAmount
        };
        
        UpdateScores();
    }

    public void AddScore(Platform platform)
    {
        switch (platform)
        {
            case Platform.Facebook:
                SaveController.facebookScore += scoreAmounts[0];
                break;
            
            case Platform.Reddit:
                SaveController.redditScore += scoreAmounts[1];
                break;
            
            case Platform.Snapchat:
                SaveController.snapchatScore += scoreAmounts[2];
                break;
            
            case Platform.Twitter:
                SaveController.twitterScore += scoreAmounts[3];
                break;
        }
        
        UpdateScores();
    }

    public void UpdateScores()
    {
        facebookText.text = SaveController.facebookScore.ToString();
        redditText.text = SaveController.redditScore.ToString();
        snapchatText.text = SaveController.snapchatScore.ToString();
        twitterText.text = SaveController.twitterScore.ToString();
    }
}
