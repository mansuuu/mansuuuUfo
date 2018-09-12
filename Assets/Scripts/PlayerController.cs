using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text countText;
    public Text winText;

    private void Start()
    {
        count = 0;
        rb2d = GetComponent<Rigidbody2D>();
        SetTextOnCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("needto update count");
        if(collision.gameObject.CompareTag ("PickUp")){
            collision.gameObject.SetActive(false);
            count = count + 1;
            SetTextOnCountText();
            Debug.Log("update count");
        }
    }

    private void SetTextOnCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 12){
            winText.text = "You Win!";
        }
    }
}
