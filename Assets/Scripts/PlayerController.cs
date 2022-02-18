using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.InputSystem;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{

    public float speed = 10;

    public int count;
    public int score;

    public Text CountTextGO;
    public Text ScoreTextGO;
    public Text loseTextGO;

    private Rigidbody rb;



    private float movementX;

    private float movementY;



    // Start is called before the first frame update

    void Start()

    {
        CountTextGO=GameObject.Find("CountText").GetComponent<Text>();
        print(CountTextGO.text);
        ScoreTextGO=GameObject.Find("ScoreText").GetComponent<Text>();
        loseTextGO=GameObject.Find("loseText").GetComponent<Text>();

        rb = gameObject.GetComponent<Rigidbody>();
        count = 10;
        score = 0;
        loseTextGO.enabled=false;
        SetScoreText();
        SetCountText();
    }



    void OnMove(InputValue movementValue)

    {

        Vector2 movementVector = movementValue.Get<Vector2>();



        movementX = movementVector.x;

        movementY = movementVector.y;

    }

    public void SetCountText(){
        CountTextGO.text = "Health: " + count.ToString();
        if (count <=0){
            loseTextGO.enabled=true;
            SceneManager.LoadScene("Prototype1");
        }
    }

    public void SetScoreText(){
        score+= 1;
        ScoreTextGO.text= "Score: " + score.ToString();
    }

    private void FixedUpdate()

    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);


        rb.AddForce(movement * speed);
        rb.velocity = movement*25;
        SetScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mob") || other.gameObject.CompareTag("ProjectileCube") ) 
            {
                Destroy(other);
                count = count-1 ;
                SetCountText();
                // if (count <=0){
                //     loseText.enabled(true);
                // }
            }

        
    }



}