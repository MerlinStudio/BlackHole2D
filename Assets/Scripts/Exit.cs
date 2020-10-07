using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject MenuCompletedLvl;
    [SerializeField] private GameObject BlockDisplay;
    [SerializeField] private GameObject Character;

    private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            //SaveJson.instance.saveData.ProgressLevel[sceneIndex] = Balls.progressLevel;

            if (sceneIndex == SaveJson.instance.saveData.Level)
            {
                SaveJson.instance.saveData.Level++;
            }

            SaveJson.instance.Saveing();

            GameTimer._start = false;
            Character.GetComponent<Animation>().Play("Exit");
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            BlockDisplay.SetActive(true);
            Invoke("Delay",1);
        }
    }

    private void Delay()
    {
        MenuCompletedLvl.SetActive(true);
    }
}
