using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class hlutursnu : MonoBehaviour
{

    public static int coin = 0;
    private TextMeshProUGUI countText;
    void Start()
    {
        countText = GameObject.Find("Text3").GetComponent<TextMeshProUGUI>();
        //sprenging= GetComponent<Explosion>
        coin = 0;
        SetCountText();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0,80,0) * Time.deltaTime);
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("náði pening");
            coin = coin + 1;//færð stig
            SetCountText();//kallar í aðferðina

            if (coin == 5)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    void SetCountText()//hér er aðferðin
    {
        countText.text = "Peningur: " + coin.ToString();
    }

}
