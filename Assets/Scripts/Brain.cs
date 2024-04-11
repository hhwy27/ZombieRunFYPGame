using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
[SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter (Collider other)
    {
        //if (other.gameObject.GetComponent<Brains>() != null) {
        //    Destroy(gameObject);
        //    return;
       // }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "FreeZombie") {
            return;
        }

        // Add to the player's score
        GameManager.inst.ChangeScore();

        // Destroy this brain object
        Destroy(gameObject);
    }

    private void Start () {

	}

	private void Update () {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
	}
}