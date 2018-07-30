using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 100;
    [SerializeField] float mainThrust = 100;

    Rigidbody rigidbody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Trhust();
        Rotate();
	}

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        { 

            case "Friendly":
                print("OK");
                break;

            case "Fuel":
                print("Fuel");
                break;

            default:
            print("Dead");
            break;


        }
    }



    private void Trhust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            rigidbody.AddRelativeForce(Vector3.up* mainThrust);
            print("Thrusting");
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        float rotateThisFrame = rcsThrust * Time.deltaTime;
        rigidbody.freezeRotation = true; //Take Manual Control of the rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward* rotateThisFrame);
            print("Rotating left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward* rotateThisFrame);
            print("Rotating right");
        }
        rigidbody.freezeRotation = false; //Resume physics controls of the rotation
    }
}
