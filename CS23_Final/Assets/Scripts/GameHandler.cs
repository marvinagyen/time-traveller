using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour {

    public GameObject past;
    public GameObject present;
    public GameObject future;

    public GameObject past_player;
    public GameObject present_player;
    public GameObject future_player;

    public GameObject textButton;

    public TextMeshProUGUI msgtxt;
    public TextMeshProUGUI TimeMarker;

    public GameObject future_pot;
    public GameObject flower_pot;
    public GameObject future_pot_w_flower;
    public GameObject picked_flower;

    public bool isPast = false;
    public bool isPresent = true;
    public bool isFuture = false;

    public GameObject progressBar1;
    public GameObject progressBar2;
    public GameObject progressBar3;

    private GameHandler_PauseMenu pause_Menu;

    public bool beenToPast = false;
    public bool beenToFuture = false;

    public AudioSource timeTravelSound;


    private GameObject player;
    Vector3 originalPos;

    //public static bool stairCaseUnlocked = false;
    //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

    private string sceneName;
    public static string lastLevelDied;  //allows replaying the Level where you died

    void Start(){
        player = GameObject.FindWithTag("Player");
        originalPos = player.transform.position;
        sceneName = SceneManager.GetActiveScene().name;
        //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
        //}

        textButton.SetActive(false);

        past.SetActive(false);
        present.SetActive(true);
        future.SetActive(false);

        past_player.SetActive(false);
        present_player.SetActive(true);
        future_player.SetActive(false);

        future_pot.SetActive(true);
        flower_pot.SetActive(false);
        future_pot_w_flower.SetActive(false);
        picked_flower.SetActive(false);

        progressBar1.SetActive(false);
        progressBar2.SetActive(false);
        progressBar3.SetActive(false);



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
        SceneManager.LoadScene("Official_scene_1");
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
                timeTravelSound.Play(0);
                if (isPresent == true) {
                    originalPos = player.transform.position;
                }
                goToPast();
                //past.SetActive(true);
                //present.SetActive(false);
                //future.SetActive(false);

                //past_player.SetActive(true);
                //present_player.SetActive(false);
                //future_player.SetActive(false);
            }
            if (Input.GetKeyDown("2"))
            {   
                timeTravelSound.Play(0);
                goToPresent();
                if (player.transform.position.x > 30) {
                    player.transform.position = originalPos;
                }
                
                //past.SetActive(false);
                //present.SetActive(true);
                //future.SetActive(false);

                //past_player.SetActive(false);
                //present_player.SetActive(true);
                //future_player.SetActive(false);
            }
            if (Input.GetKeyDown("3"))
            {
                timeTravelSound.Play(0);
                if (isPresent == true) {
                    originalPos = player.transform.position;
                }
                goToFuture();
                //past.SetActive(false);
                //present.SetActive(false);
                //future.SetActive(true);

                //past_player.SetActive(false);
                //present_player.SetActive(false);
                //future_player.SetActive(true);
            }
        }
    }


    public void goToPast(){
        

        TimeMarker.text = "Past";

        isPast = true;
        isPresent = false;
        isFuture = false;

        past.SetActive(true);
        present.SetActive(false);
        future.SetActive(false);

        past_player.SetActive(true);
        present_player.SetActive(false);
        future_player.SetActive(false);
        if (!beenToPast)
        {
            string message = "Did I go back in time...?!\nHey I think the lab door might finally be open!";
            makeMessagesAppear(message);
        }
        beenToPast = true;
    }

    public void goToPresent(){

        TimeMarker.text = "Present";

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
        TimeMarker.text = "Future";

        isPast = false;
        isPresent = false;
        isFuture = true;

        past.SetActive(false);
        present.SetActive(false);
        future.SetActive(true);

        past_player.SetActive(false);
        present_player.SetActive(false);
        future_player.SetActive(true);
    
        if (!beenToFuture)
        {
            string message = "Did I travel to the future...?!\nNow try pressing 1!";
            makeMessagesAppear(message);
        }
        beenToFuture = true;
    }

    public void closeTextButton() {

        textButton.SetActive(false);
        //Debug.Log("text");
    }

    public void makeMessagesAppear(string message)
    {
        msgtxt.text = message;
        textButton.SetActive(true);
        //if (player.GetComponent<PlayerMove_2>().canTimeTravel)
        //{
        //    textButton.SetActive(true);
        //}
    }
}
