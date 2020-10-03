using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnloader : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }

    public void UnloadScene(int index)
    {
        SceneManager.UnloadSceneAsync(index);
    }
}
