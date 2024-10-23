using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // rigidbody of player
    private Rigidbody rb;

    private int count;

    //hreyfing
    private float movementX;
    private float movementY;

    // hraði
    public float speed = 0;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ná í og geyma player rigidbody component
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    // er kallað á þegar move input er detect-að
    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 11)
        {
            winTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winTextObject.gameObject.SetActive(true);
            // breytir wintext
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
}
