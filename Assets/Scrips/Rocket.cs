using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcesInput();
	}

    private void ProcesInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            rigidbody.AddRelativeForce(Vector3.up);
            print("Thrusting");
        }
        else
        {
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
            print("Rotating left");
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward);
            print("Rotating right");
        }
    }
}
