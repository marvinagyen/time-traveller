using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingScene : MonoBehaviour
{
    // Start is called before the first frame updat
    void OnEnable() {
        SceneManager.LoadScene("MainMenu1", LoadSceneMode.Single);
    }


}
