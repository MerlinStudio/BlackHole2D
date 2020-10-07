using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveJson : MonoBehaviour
{
    public static SaveJson instance = null;

    public Save saveData = new Save();

    private int sceneIndex;

    [Serializable]
    public class Save
    {
        public int Level;
        public int[] ProgressLevel;
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (!PlayerPrefs.HasKey("Save"))
        {
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(saveData));
        }
        else
            saveData = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));

        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Balls.progressLevel = saveData.ProgressLevel[sceneIndex];
    }

    public void Saveing()
    {
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(saveData));
    }
}
