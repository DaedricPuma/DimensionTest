using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public Button continueButton;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
    }


    void ContinueGame()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") == 2)
        {
            //SceneManager.LoadScene("Level 2");
            StartCoroutine(LoadAsynchronously("Level 2"));
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 3)
        {
            //SceneManager.LoadScene("Level 3");
            StartCoroutine(LoadAsynchronously("Level 3"));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsynchronously(string scene)
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
