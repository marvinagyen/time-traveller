using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable() {
        SceneManager.LoadScene("Official_scene_1", LoadSceneMode.Single);
    }
}
