using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; 
  
public class PlayerController : MonoBehaviour   
{  
     
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultipler = 2;
    int brainsCollected;

    public GameObject WinText;

    public float speedIncreasePoints = 0.1f;

    [SerializeField] float jumpForce = 400f;

    [SerializeField] LayerMask groundMask;

    // Start is called before the first frame update  
    void Start()  
    {  
        WinText.SetActive(false);
        rb = GetComponent<Rigidbody>(); 
    }

    //Fixed
    private void FixedUpdate ()
    {
        Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 moveHorizontal = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultipler;
        rb.MovePosition(rb.position + moveForward + moveHorizontal);
    }
    
    // Update is called once per frame  
    private void Update()  
    {  
        horizontalInput = Input.GetAxis("Horizontal");

        //resets the players position by resetting the game if they fall off the path
        if(transform.position.y <= -5f)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }  

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Spikes")
        {
            SceneManager.LoadScene(0);
        }

        if ( other.tag == "Brain" )
        {
            brainsCollected++;
            other.gameObject.SetActive(false);
        }


        if(brainsCollected >= 35)
        {
            WinText.SetActive(true);
        }
    }

    void Jump ()
    {
        //check if grounded 
        float height = GetComponent<Collider>().bounds.size.y; 
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.1f, groundMask);

        //if so, JUMP
        rb.AddForce(Vector3.up * jumpForce);
    }


}
