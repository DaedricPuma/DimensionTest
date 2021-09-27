using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button play;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") != 2 && PlayerPrefs.GetInt("CurrentLevel") != 3)
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
        play.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        PlayerPrefs.SetInt("CurrentLevel", 1);
        //SceneManager.LoadScene("Level 1-1");

        StartCoroutine(LoadAsynchronously("Level 1-1"));
    }

    IEnumerator LoadAsynchronously (string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
