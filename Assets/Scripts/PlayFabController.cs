using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels; 

public class PlayFabController : MonoBehaviour
{
    void Start()
    {
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest
            {
                TitleId = PlayFabSettings.TitleId,
                CustomId = "1000",
                CreateAccount = true,
            }
        , result =>
        {
            Debug.Log("ログイン成功！");
            //SubmitScore(500);
        }
        ,error =>
        {
            Debug.Log("ログイン失敗");
        });

    }
    public void SubmitScore(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "sushiShotRanking",
                    Value = playerScore
                }
            }
        }, result =>
        {
            Debug.Log($"スコア {playerScore} 送信完了！");
        }, error =>
        {
            Debug.Log(error.GenerateErrorReport());
        });
    }
    
    public void GetLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "sushiShotRanking"
        }, result =>
        {
            foreach (var item in result.Leaderboard)
            {
                Debug.Log($"{item.Position + 1}位:{item.DisplayName} " + $"スコア {item.StatValue}");
            }
        }, error =>
        {
            Debug.Log(error.GenerateErrorReport());
        });
    }
}

