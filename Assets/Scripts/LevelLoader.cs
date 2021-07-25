using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    [SerializeField] Material skybox;    
    [SerializeField] GameObject loadingSene;

    [SerializeField] Slider slider;
    [SerializeField] Text progressText;

    private void Awake() 
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexs.MAIN_MENU, LoadSceneMode.Additive);
    }


    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadLevel()
    {
        loadingSene.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexs.MAIN_MENU));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexs.FTS, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress());        
    }   

    float totalSceneProgress;
    IEnumerator GetSceneLoadProgress ()   
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;
                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress =+ operation.progress;
                }

                totalSceneProgress = Mathf.Clamp01(totalSceneProgress / .9f); 

                slider.value = totalSceneProgress;

                progressText.text = totalSceneProgress * 100 + "%";


                yield return null;
            }
        }            

    }

    public void AnyKey()
    {
        if(scenesLoading[1].isDone)
        {
        Destroy(loadingSene);
        RenderSettings.skybox = skybox;
        Destroy(gameObject);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.instance.Play("Click");
    }

}
