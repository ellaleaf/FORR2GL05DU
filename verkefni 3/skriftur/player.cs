using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Endurr�sa();
        }
    }
    public void Endurr�sa()
    {
        SceneManager.LoadScene(3);
    }
}
