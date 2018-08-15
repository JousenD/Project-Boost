using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {
    [Range(0, 1)] [SerializeField] float movementFactor;
    [SerializeField] Vector3 movementVector;
    Vector3 startingPos;

    [SerializeField] float period = 2f;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = 2 * Mathf.PI;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = rawSinWave / 2f +0.5f ;

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
	}
}
