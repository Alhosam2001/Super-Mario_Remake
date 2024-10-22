using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private SceneLoader loadScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevel(int levelIndex)
    {
        loadScene.LoadLevel(levelIndex);
    }
}
