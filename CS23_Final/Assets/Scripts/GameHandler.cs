using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

    public GameObject past;
    public GameObject present;
    public GameObject future;

    public GameObject past_player;
    public GameObject present_player;
    public GameObject future_player;

    public GameObject textButton;
    public GameObject watchMessage;
    public GameObject poisonMessage;

    public GameObject future_pot;
    public GameObject flower_pot;

    public bool isPast = false;
    public bool isPresent = true;
    public bool isFuture = false;

    public GameObject progressBar1;

    private GameHandler_PauseMenu pause_Menu;

    //public GameObject Player


    private GameObject player;

    //public static bool stairCaseUnlocked = false;
    //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

    private string sceneName;
    public static string lastLevelDied;  //allows replaying the Level where you died

    void Start(){
        player = GameObject.FindWithTag("Player");
        sceneName = SceneManager.GetActiveScene().name;
        //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
        //}

        textButton.SetActive(false);
        watchMessage.SetActive(false);
        poisonMessage.SetActive(false);

        past.SetActive(false);
        present.SetActive(true);
        future.SetActive(false);

        past_player.SetActive(false);
        present_player.SetActive(true);
        future_player.SetActive(false);

        future_pot.SetActive(true);
        flower_pot.SetActive(false);

   

    }

    public void playerDies(){
        // player.GetComponent<PlayerHurt>().playerDead();       //play Death animation
        lastLevelDied = sceneName;       //allows replaying the Level where you died
        StartCoroutine(DeathPause());
    }

    IEnumerator DeathPause(){
        // player.GetComponent<PlayerMove>().isAlive = false;
        // player.GetComponent<PlayerJump>().isAlive = false;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("EndLose");
    }

    // Loads the first scene in the game, will likely be first level
    public void StartGame() {
        SceneManager.LoadScene("Level1");
    }

      // Return to MainMenu
    public void RestartGame() {
        Time.timeScale = 1f;
        pause_Menu.GameisPaused = false;
        SceneManager.LoadScene("MainMenu");
        // Reset all static variables here, for new games:
    }

      // Replay the Level where you died
    public void ReplayLastLevel() {
        Time.timeScale = 1f;
        pause_Menu.GameisPaused = false;
        SceneManager.LoadScene(lastLevelDied);
        // Reset all static variables here, for new games:
    }

    // Exit Unity Application
    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }   

    // Trigger Credits scene
    public void Credits() {
        SceneManager.LoadScene("Credits");
        }

    
    public void Update()
    {
        // FOR CHANGING SCENES
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMove_2>().canTimeTravel)
        {
            if (Input.GetKeyDown("1"))
            {
                past.SetActive(true);
                present.SetActive(false);
                future.SetActive(false);

                past_player.SetActive(true);
                present_player.SetActive(false);
                future_player.SetActive(false);
            }
            if (Input.GetKeyDown("2"))
            {
            
                past.SetActive(false);
                present.SetActive(true);
                future.SetActive(false);

                past_player.SetActive(false);
                present_player.SetActive(true);
                future_player.SetActive(false);
            }
            if (Input.GetKeyDown("3"))
            {
                past.SetActive(false);
                present.SetActive(false);
                future.SetActive(true);

                past_player.SetActive(false);
                present_player.SetActive(false);
                future_player.SetActive(true);
            }
        }
    }


    public void goToPast(){
        isPast = true;
        isPresent = false;
        isFuture = false;

        past.SetActive(true);
        present.SetActive(false);
        future.SetActive(false);

        past_player.SetActive(true);
        present_player.SetActive(false);
        future_player.SetActive(false);
    }

    public void goToPresent(){

        isPast = false;
        isPresent = true;
        isFuture = false;

        past.SetActive(false);
        present.SetActive(true);
        future.SetActive(false);

        past_player.SetActive(false);
        present_player.SetActive(true);
        future_player.SetActive(false);
    }

    public void goToFuture()
    {

        isPast = false;
        isPresent = false;
        isFuture = true;

        past.SetActive(false);
        present.SetActive(false);
        future.SetActive(true);

        past_player.SetActive(false);
        present_player.SetActive(false);
        future_player.SetActive(true);
    }

    public void closeTextButton() {

        textButton.SetActive(false);
        watchMessage.SetActive(false);
        poisonMessage.SetActive(false);
        //Debug.Log("text");
    }

    public void makeMessagesAppear()
    {
        if (player.GetComponent<PlayerMove_2>().canTimeTravel)
        {
            textButton.SetActive(true);
        }
    }
}
