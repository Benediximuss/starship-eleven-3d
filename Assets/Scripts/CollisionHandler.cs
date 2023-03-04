using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    private bool isHit = false;
    private float hitTime = 0f;
    [SerializeField] float resetAfter = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) || (isHit && (Time.time - hitTime) >= resetAfter))
        {
            ReloadScene();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                Debug.Log("COIN!");
                break;
            case "Finish":
                Debug.Log("Finish");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "Friendly":
                break;
            default:
                Debug.Log("OOPSS!");

                DisableMovement();

                isHit = true;
                hitTime = Time.time;

                break;
        }
    }

    private void DisableMovement()
    {
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
