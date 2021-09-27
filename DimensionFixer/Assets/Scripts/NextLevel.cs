using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    private Scene scene;
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (scene.name == "Level 1-1")
            {
                PlayerPrefs.SetInt("CurrentLevel", 2);
                //SceneManager.LoadScene("Level 2");
                StartCoroutine(LoadAsynchronously("Level 2"));
            }
            else if (scene.name == "Level 2")
            {
                PlayerPrefs.SetInt("CurrentLevel", 3);
                //SceneManager.LoadScene("Level 3");
                StartCoroutine(LoadAsynchronously("Level 3"));
            }
            //SceneManager.LoadScene("Level 2");
        }
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
