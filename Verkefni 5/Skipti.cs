using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("byrja");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("h�ho");
        other.gameObject.SetActive(false);
        StartCoroutine(Bida());
    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurr�sa();
    }
    public void Endurr�sa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//n�sta sena
    }

}
