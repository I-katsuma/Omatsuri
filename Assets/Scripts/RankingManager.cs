using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    [SerializeField]
    private Text _nameText;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _rankingText;
    private string rankingName = "sushiShotRanking2";

    ///
    //  ユーザー名を更新
    ///
    public void UpdateUserName() // ボタンに貼り付け
    {
        //ユーザ名を指定して、UpdateUserTitleDisplayNameRequestのインスタンスを生成
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = _nameText.text };

        //ユーザ名の更新
        Debug.Log($"ユーザ名の更新開始");
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            request,
            OnUpdateUserNameSuccess,
            OnUpdateUserNameFailure
        );
    }

    //ユーザ名の更新成功
    private void OnUpdateUserNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        //result.DisplayNameに更新した後のユーザ名が入ってる
        Debug.Log($"ユーザ名の更新が成功しました : {result.DisplayName}");
    }

    //ユーザ名の更新失敗
    private void OnUpdateUserNameFailure(PlayFabError error)
    {
        Debug.LogError($"ユーザ名の更新に失敗しました\n{error.GenerateErrorReport()}");
    }

    ///
    // スコアを更新
    ///
    public void UpdatePlayerStatistics()
    {
        //UpdatePlayerStatisticsRequestのインスタンスを生成
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = rankingName, //ランキング名(統計情報名)
                    Value = int.Parse(_scoreText.text), //スコア(int)
                }
            }
        };

        //ユーザ名の更新
        Debug.Log($"スコア(統計情報)の更新開始");
        PlayFabClientAPI.UpdatePlayerStatistics(
            request,
            OnUpdatePlayerStatisticsSuccess,
            OnUpdatePlayerStatisticsFailure
        );
    }

    //スコア(統計情報)の更新成功
    private void OnUpdatePlayerStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"スコア(統計情報)の更新が成功しました");
    }

    //スコア(統計情報)の更新失敗
    private void OnUpdatePlayerStatisticsFailure(PlayFabError error)
    {
        Debug.LogError($"スコア(統計情報)更新に失敗しました\n{error.GenerateErrorReport()}");
    }

    ///
    // ランキング取得
    ///
    public void GetLeaderboard()
    {
        //GetLeaderboardRequestのインスタンスを生成
        var request = new GetLeaderboardRequest
        {
            StatisticName = rankingName, //ランキング名(統計情報名)
            StartPosition = 0, //何位以降のランキングを取得するか
            MaxResultsCount = 5 //ランキングデータを何件取得するか(最大100)
        };

        //ランキング(リーダーボード)を取得
        Debug.Log($"ランキング(リーダーボード)の取得開始");
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }

    //ランキング(リーダーボード)の取得成功
    private void OnGetLeaderboardSuccess(GetLeaderboardResult result)
    {
        Debug.Log($"ランキング(リーダーボード)の取得に成功しました");

        //result.Leaderboardに各順位の情報(PlayerLeaderboardEntry)が入っている
        _rankingText.text = "";
        foreach (var entry in result.Leaderboard)
        {
            _rankingText.text +=
                //$"\n順位 : {entry.Position + 1}, スコア : {entry.StatValue}, 名前 : {entry.DisplayName}, ID : {entry.PlayFabId}";
            $"\nRANK : {entry.Position + 1}, SCORE : {entry.StatValue}, NAME : {entry.DisplayName}";

        }
    }

    //ランキング(リーダーボード)の取得失敗
    private void OnGetLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
    }

}
