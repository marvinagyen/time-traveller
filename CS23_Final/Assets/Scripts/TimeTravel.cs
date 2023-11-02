using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public GameObject past;
    public GameObject present;
    public GameObject future;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

    public void goToPast() 
    {
        past.SetActive(true);
        present.SetActive(false);
        future.SetActive(false);
    }

    public void goToPresent()
    {
        past.SetActive(false);
        present.SetActive(true);
        future.SetActive(false);
    }

    public void goToFuture()
    {
        past.SetActive(false);
        present.SetActive(false);
        future.SetActive(true);
    }
}
