using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawnController : MonoBehaviour {

    public GameObject ringSpawner;

    GameManager mainGameManager;

    [SerializeField]
    float spawnDelay;
    float nextTimeToSpawn = 0f;
    [SerializeField]
    float shrinkRate;
    [SerializeField]
    float spawnDecrement;
    [SerializeField]
    Vector2 minMaxSpawnDelay;

    bool makeRingsSpinBool;
    bool makeRingsSpinOppBool;
    bool makeRingsSpinRandomBool;
    bool increaseSpinSpeedBool;
    bool decreaseSpinSpeedBool;

    private void Start()
    {
        mainGameManager = GetComponent<GameManager>();
    }

    void Update () {
		if(Time.time >= nextTimeToSpawn && mainGameManager.gameStarted)
        {
            nextTimeToSpawn = Time.time + spawnDelay;
            GameObject ringInstance = (GameObject)Instantiate(ringSpawner, transform);
            SetRingShrinkRate(ringInstance);
            SetRingSpin(ringInstance);
        }
	}

    void SetRingShrinkRate(GameObject _ringInstance)
    {
        _ringInstance.GetComponent<RingController>().SetShrinkRate(shrinkRate);
    }

    void SetRingSpin(GameObject _ringInstance)
    {
        if (makeRingsSpinBool)
        {
            _ringInstance.GetComponent<RingController>().SetSpin(true, true);
        }
        else if (makeRingsSpinOppBool)
        {
            _ringInstance.GetComponent<RingController>().SetSpin(true, false);
        }
        else if (makeRingsSpinRandomBool)
        {
            _ringInstance.GetComponent<RingController>().SetSpin(true, false, true);
        }

        if (increaseSpinSpeedBool)
        {
            _ringInstance.GetComponent<RingController>().IncreaseRingSpeed();
        }
        else if (decreaseSpinSpeedBool)
        {
            _ringInstance.GetComponent<RingController>().DecreaseRingSpeed();
        }
    }

    

    public void DecreaseSpawnDelay()
    {
        spawnDelay -= spawnDecrement;
        spawnDelay = Mathf.Clamp(spawnDelay, minMaxSpawnDelay.x, minMaxSpawnDelay.y);
    }

    public void MakeRingsSpin()
    {
        makeRingsSpinBool = true;
        makeRingsSpinOppBool = false;
        makeRingsSpinRandomBool = false;
    }
    
    public void MakeRingsSpinOpp()
    {
        makeRingsSpinBool = false;
        makeRingsSpinOppBool = true;
        makeRingsSpinRandomBool = false;
    }

    public void MakeRingsSpinRandom()
    {
        makeRingsSpinBool = false;
        makeRingsSpinOppBool = false;
        makeRingsSpinRandomBool = true;
    }

    public void IncreaseSpinSpeed()
    {
        increaseSpinSpeedBool = true;
        decreaseSpinSpeedBool = false;
    }

    public void DecreaseSpinSpeed()
    {
        increaseSpinSpeedBool = false;
        decreaseSpinSpeedBool = true;
    }
}
