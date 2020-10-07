using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Loading screen")]
    [SerializeField] private GameObject PanelLoadingScane;
    [SerializeField] private Image LoadingImage;
    [SerializeField] private Text ProgressText;

    [Space]
    [SerializeField] private GameObject Messege_2;

    [Space]
    [SerializeField] private int AllLevel;



    private int level;
    private int sceneIndex;


    public void LoadScene(int scene) // Call with button 
    {
        level = scene;
        StartCoroutine(AsyncLoad());
    }
    IEnumerator AsyncLoad()
    {
        PanelLoadingScane.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            LoadingImage.fillAmount = progress;
            ProgressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }

    public void RestartLevel() // Call with button restart
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SaveJson.instance.saveData.ProgressLevel[0] = 0;
        SaveJson.instance.saveData.ProgressLevel[sceneIndex] = 0;
        SaveJson.instance.Saveing();
    }

    public void NextLevel() // Call with button next
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex + 1 <= AllLevel)
        {
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
            Messege_2.SetActive(true);
    }


    //private void OnApplicationPause(bool pause)
    //{
    //    PlayerPrefs.SetString("Save1", JsonUtility.ToJson(saveData));
    //}

    //  private void OnApplicationQuit()
    //    {
    //    PlayerPrefs.SetString("Save1", JsonUtility.ToJson(saveData));
    //}
}
