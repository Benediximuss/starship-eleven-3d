using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{

    AudioSource audioSource;
    MeshRenderer meshRenderer;
    Color originalColor;
    Color hitColor;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        originalColor = GetComponent<MeshRenderer>().material.color;
        hitColor = new Color(0.61f, 0.15f, 0.12f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        meshRenderer.material.color = hitColor;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        meshRenderer.material.color = originalColor;
    }

}
