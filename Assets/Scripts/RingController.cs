using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour {

    public delegate void RingCrossed();
    public static event RingCrossed ringCrossed;
    
    [SerializeField]
    float shrinkRate;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float rotationSpeedFactor;

    [SerializeField]
    bool makeRingSpin;
    [SerializeField]
    bool spinRingClockwise;
    [SerializeField]
    bool spinRandom;
    [SerializeField]
    int[] randomSpinDirections;

    Rigidbody2D rb;
    int randomSpinDirection;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = Random.Range(0, 360);
	}
	
	void Update () {
        if (makeRingSpin)
        {
            SpinRing();
        }

        ShrinkRing();

        if (transform.localScale.x <= 0f)
        {
            DestroyRing();
        }
	}

    void SpinRing()
    {
        if (spinRingClockwise)
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        else if (spinRandom)
        {
            transform.Rotate(Vector3.forward, randomSpinDirection * rotationSpeed * Time.deltaTime);
        }
        else if (!spinRingClockwise && !spinRandom)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    void ShrinkRing()
    {
        transform.localScale -= Vector3.one * shrinkRate * Time.deltaTime;
    }

    void DestroyRing()
    {
        ringCrossed();
        Destroy(gameObject);
    }

    public void IncreaseRingSpeed()
    {
        rotationSpeed *= rotationSpeedFactor;
    }

    public void DecreaseRingSpeed()
    {
        rotationSpeed /= rotationSpeedFactor;
    }

    public void SetSpin(bool _value, bool _spindirection)
    {
        makeRingSpin = _value;
        spinRingClockwise = _spindirection;
    }

    public void SetSpin(bool _value, bool _spindirection, bool _spinRandom)
    {
        makeRingSpin = _value;
        spinRingClockwise = _spindirection;
        spinRandom = _spinRandom;
        randomSpinDirection = randomSpinDirections[Random.Range(0,2)];
    }

    public void SetShrinkRate(float _value)
    {
        shrinkRate = _value;
    }
}
