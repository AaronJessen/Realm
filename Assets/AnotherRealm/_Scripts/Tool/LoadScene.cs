using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void JumpToScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
        
    }

    public static void JumpToNextLevel(int index)
    {
        SceneManager.LoadSceneAsync(index);

    }
}
