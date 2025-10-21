using UnityEngine;
public class Cubemanager : MonoBehaviour
{
    GameObject Cube_Object = new GameObject();
    
    void Start()
    {
        
        //Instantiate(Cube_Object);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("k ´­·¶½À´Ï´Ù.");
        }
    }
}
