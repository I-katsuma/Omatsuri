using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Text;

public class PlayfabLogin : MonoBehaviour
{
    private bool _shouldCreateAccount; // アカウントを作るかどうか
    private string _customID; // ログイン時に使うID

    [SerializeField] RankingManager rankingManager;

    public void Start()
    {
        Login();
        
    }

    private void Login() // ログイン実行
    {
        _customID = LoadCustomID();
        var request = new LoginWithCustomIDRequest
        {
            CustomId = _customID,
            CreateAccount = _shouldCreateAccount
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        //rankingManager.GetLeaderboard();
    }

    //ログイン成功
    private void OnLoginSuccess(LoginResult result)
    {
        // アカウントを作成しようとしたのに、IDが既に使われていて、出来なかった場合
        if (_shouldCreateAccount && !result.NewlyCreated)
        {
            Debug.LogWarning($"CustomId : {_customID} は既に使われています。");
            Login(); // ログインしなおし
            return;
        }

        // アカウント作成時にIDを保存
        if (result.NewlyCreated)
        {
            SaveCustomID();
        }
        rankingManager.GetLeaderboard();
        Debug.Log(
            $"PlayFabのログインに成功\nPlayFabId : {result.PlayFabId}, CustomId : {_customID}\nアカウントを作成したか : {result.NewlyCreated}"
        );
    }

    //ログイン失敗
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"PlayFabのログインに失敗\n{error.GenerateErrorReport()}");
    }

    // IDを保存するときのKEY
    private static readonly string CUSTOM_ID_SAVE_KEY = "CUSTOM_ID_SAVE_KEY";

    // IDを取得
    private string LoadCustomID()
    {
        // IDを取得
        string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);

        // 保存されていなければ新規生成
        _shouldCreateAccount = string.IsNullOrEmpty(id);
        return _shouldCreateAccount ? GenerateCustomID() : id;
    }

    // IDの保存
    private void SaveCustomID()
    {
        PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, _customID);
    }

    // IDに使用する文字
    private static readonly string ID_CHARACTERS = "0123456789abcdefghijklmnopqrstuvwxyz";

    // IDを生成
    private string GenerateCustomID()
    {
        int idLength = 32;
        StringBuilder stringBuilder = new StringBuilder(idLength);
        var random = new System.Random();

        // ランダムにIDを生成
        for (int i = 0; i < idLength; i++)
        {
            stringBuilder.Append(ID_CHARACTERS[random.Next(ID_CHARACTERS.Length)]);
        }
        return stringBuilder.ToString();
    }
}
