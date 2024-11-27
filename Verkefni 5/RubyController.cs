using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public static int stig;
    private TextMeshProUGUI countText;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        stig = 0;
        SetCountText();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "skrimsli") 
        {
            stig -= 1; 

            collision.collider.gameObject.SetActive(false);

            if (stig < 0)
            {
                die();
            }
        }
        if (collision.collider.tag == "orn")
        {
            stig -= 2;

            collision.collider.gameObject.SetActive(false);

            if (stig < 0)
            {
                die();
            }
        }
        if (collision.collider.tag == "gim") 
        {
           stig += 1; 

            collision.collider.gameObject.SetActive(false); 
        }
        SetCountText();
    }
    void SetCountText()//hér er aðferðin
    {
        countText.text = "Stig: " + stig.ToString();
    }

    void die()
    {
        SceneManager.LoadScene(2);
    }


}
