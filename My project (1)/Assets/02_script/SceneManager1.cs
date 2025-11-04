using UnityEngine;

public class SceneManager1 : MonoBehaviour
{
    void Start()
    {
        
    }
    public void NextScene(string mv_scene)
    {
        Application.LoadLevel(mv_scene);
    }

    public void AppClose()
    {
        Application.Quit();
    }
}
