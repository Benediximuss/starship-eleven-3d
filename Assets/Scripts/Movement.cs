using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] float thrust = 1000f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private Rigidbody rigidBody;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetPositionAndRotation(out initialPosition, out initialRotation);

        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            rigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
        else
        {
            audioSource.Pause();
        }

    }

}
