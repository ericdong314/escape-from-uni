using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    private Vector3 startPoint;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "NextRoom")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            startPoint = transform.position;
        }
        else if (collision.tag == "PreviousRoom")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            startPoint = transform.position;
        }
    }
}
