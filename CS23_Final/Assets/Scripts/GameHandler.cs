using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject past;
    public GameObject present;
    public GameObject future;

    public GameObject past_player;
    public GameObject present_player;
    public GameObject future_player;

    public GameObject textButton;

    public GameObject Player;



    // Start is called before the first frame update
    void Start()
    {
        textButton.SetActive(false);

        past.SetActive(false);
        present.SetActive(true);
        future.SetActive(false);

        past_player.SetActive(false);
        present_player.SetActive(true);
        future_player.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        makeMessagesAppear();
        

    }

    public void goToPast()
    {
        past.SetActive(true);
        present.SetActive(false);
        future.SetActive(false);

        past_player.SetActive(true);
        present_player.SetActive(false);
        future_player.SetActive(false);
    }

    public void goToPresent()
    {
        past.SetActive(false);
        present.SetActive(true);
        future.SetActive(false);

        past_player.SetActive(false);
        present_player.SetActive(true);
        future_player.SetActive(false);
    }

    public void goToFuture()
    {
        past.SetActive(false);
        present.SetActive(false);
        future.SetActive(true);

        past_player.SetActive(false);
        present_player.SetActive(false);
        future_player.SetActive(true);
    }

    public void closeTextButton()
    {
        textButton.SetActive(false);
    }

    void makeMessagesAppear()
    {
        if (Player.GetComponent<PlayerMove_2>().canTimeTravel)
        {
            textButton.SetActive(true);
        } else
        {
            textButton.SetActive(false);
        }
    }
}
