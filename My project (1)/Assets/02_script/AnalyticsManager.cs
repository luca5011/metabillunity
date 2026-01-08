using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance;

    [Header("Game Settings")]
    private string gameId = "Game_Sunwoo_01";
    private string gameTitle = "Shift!";
    private string developer = "김선우";

    private string userUuid;
    private string playSessionKey;
    private int attemptCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 씬이 로드될 때마다 자동으로 LogStageStart가 호출되도록 이벤트 등록
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else { Destroy(gameObject); }

        InitUserUuid();
        playSessionKey = "PS_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
    }

    private void InitUserUuid()
    {
        userUuid = PlayerPrefs.GetString("User_Unique_ID", "");
        if (string.IsNullOrEmpty(userUuid))
        {
            userUuid = Guid.NewGuid().ToString();
            PlayerPrefs.SetString("User_Unique_ID", userUuid);
            PlayerPrefs.Save();
        }
    }

    // 씬이 로드될 때 유니티가 자동으로 호출해주는 시스템 이벤트
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 로비나 메인화면 등 로그를 찍고 싶지 않은 씬이 있다면 예외 처리가 가능합니다.
        LogStageStart();
    }

    public void LogStageStart()
    {
        attemptCount++;
        StartCoroutine(SendRequest("start"));
    }

    // 다음 씬 이름을 매개변수로 받아 전송 완료 후 이동
    public void LogStageClear(string nextSceneName)
    {
        // 전송 완료 후 실행할 동작(Action)을 코루틴에 전달
        StartCoroutine(SendRequest("clear", () => {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }));
    }

    // 콜백 함수(onDone)를 추가하여 전송 완료 시점을 파악
    IEnumerator SendRequest(string action, Action onDone = null)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        WWWForm form = new WWWForm();

        form.AddField("gameId", gameId);
        form.AddField("userUuid", userUuid);
        form.AddField("playSessionKey", playSessionKey);
        form.AddField("attemptId", "At_" + attemptCount.ToString("D3"));
        form.AddField("sceneName", sceneName);
        form.AddField("action", action);
        form.AddField("gameTitle", gameTitle);
        form.AddField("developer", developer);

        using (UnityWebRequest www = UnityWebRequest.Post("https://metavillab.com/firebase/api/game/game_userdataSave_a1.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"전송성공: {action} - {attemptCount}회차");
                // 전송이 성공하면 예약된 동작(씬 이동 등)을 실행
                onDone?.Invoke();
            }
            else
            {
                Debug.LogError($"전송실패: {www.error}");
                // 실패하더라도 게임 진행을 위해 씬 이동을 시켜주는 것이 좋습니다.
                onDone?.Invoke();
            }
        }
    }

    private void OnDestroy()
    {
        // 메모리 누수 방지를 위한 이벤트 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}