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
            Endurræsa();
        }
    }
    public void Endurræsa()
    {
        SceneManager.LoadScene(3);
    }
}
