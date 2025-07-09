using UnityEngine;
using UnityEngine.SceneManagement;
public class Start_Handler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool paused = false;
    public bool gameovered = false;
    public AudioClip myClip;
    public GameObject gameovertext;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         PauseRoutine();
         GameOverHandler();

    }

    void PauseRoutine(){
        if (!gameovered && Input.GetButtonDown("Start")){
            if (myClip) GetComponent<AudioSource>().PlayOneShot(myClip);
            if (paused) {
                Time.timeScale = 1;
                paused = false;
            } else {
                Time.timeScale = 0;
                paused = true;
            }
        }
    }
    void GameOverHandler(){
        if (gameovered && Input.GetButtonDown("Start")){
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
    }
    public void GameOver(){
        gameovertext.SetActive(true);
        paused = true;
        gameovered = true;
        Time.timeScale = 0;

    }
}
