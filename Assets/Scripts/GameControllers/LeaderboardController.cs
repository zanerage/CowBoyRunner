using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames;
public class LeaderboardController : MonoBehaviour
{
    public static LeaderboardController instance;

    private const string LEADERBOARDS_SCORE = "CggI7aORywoQAhAG";

    private Button leaderboardsBtn;


    void Awake()
    {
        MakeSingleton();
        GetTheButton();
    }
    void Start()
    {
        PlayGamesPlatform.Activate();
    }
    void GetTheButton()
    {
        leaderboardsBtn = GameObject.Find("Leaderboards").GetComponent<Button>();
        leaderboardsBtn.onClick.RemoveAllListeners();
        leaderboardsBtn.onClick.AddListener(() => OpenLeaderboard());
    }
   void OnLevelWasLoaded()
    {
        PostScore();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void OpenLeaderboard()
    {
        if(Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARDS_SCORE);

        } else
        {
            Social.localUser.Authenticate((bool succes) =>
            {

            });
        }


    }
    void PostScore()
    {
        if(Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("Score"),LEADERBOARDS_SCORE,(bool success)=>
            {


            });
            

        }
    }

}
