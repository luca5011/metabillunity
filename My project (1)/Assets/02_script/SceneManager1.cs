using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager1 : MonoBehaviour
{
    void Start()
    {
        
    }
    public void NextScene(string mv_scene)
    {
        Application.LoadLevel(mv_scene);
    }

    public void ResceneLoad()
    {
        string NowSceneName = SceneManager.GetActiveScene().name;
        Application.LoadLevel(NowSceneName);
    }
    public void AppClose()
    {
        Application.Quit();
    }
}
