/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance;

    public static SceneManager Instance
    {
        get{
            if (instance == null)
            {
                instance = FindObjectOfType<SceneManager>();
            }

            return instance;
        }
    }

    public Dictionary<string, BaseScene> sceneDictionary = new Dictionary<string, BaseScene>();
    private string currentSceneName = null;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<SceneManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        if (currentSceneName == null)
        {
            currentSceneName = "Login";
        }
        else
        {
            currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        }

        RegisterScene(currentSceneName);
    }

    public BaseScene GetSceneClass(string sceneName)
    {
        if (sceneName == "Login") return gameObject.AddComponent<LoginScene>();
        if (sceneName == "Lobby") return gameObject.AddComponent<LobbyScene>();

        return null;
    }

    public void RemoveSceneClass(string sceneName)
    {
        if (sceneName == "Login") Destroy(GetComponent<LoginScene>());
        if (sceneName == "Lobby") Destroy(GetComponent<LobbyScene>());
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public string GetCurrentSceneName()
    {
        return currentSceneName;
    }

    public void RegisterScene(string sceneName)
    {
        currentSceneName = sceneName;
        if(!sceneDictionary.ContainsKey(sceneName)) // 딕셔너리에 Key 값이 있는지 검사
        {
            BaseScene tempScene = GetSceneClass(sceneName);
            tempScene.sceneName = sceneName;
            sceneDictionary.Add(sceneName, tempScene);
        }
    }

    public BaseScene GetScene (string sceneName)
    {
        if (sceneDictionary.ContainsKey(sceneName)) // 딕셔너리 Key 값이 있는지 검사
        {
            return sceneDictionary[sceneName];      // 딕셔너리 Key 배열처럼 가져온다.
        }
        return null;
    }

    public void UnloadScene(string sceneName)
    {
        if (sceneDictionary.ContainsKey(sceneName))
        {
            sceneDictionary.Remove(sceneName);
            RemoveSceneClass(sceneName);
        }
    }

    public IEnumerator LoadSceneButton(string sceneName)
    {
        UnloadScene(currentSceneName);
        yield return new WaitForSeconds(0.5f);
        LoadScene(sceneName);
    }

    public void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        RegisterScene(currentSceneName);
    }

    public void OnDisable()
    {
        UnityEngine.;
    }
}*/
