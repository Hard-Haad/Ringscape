using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public AudioManager mainAudioManager;
    public GameManager mainGameManager;
    public GameObject playerObject;
    public GameObject onPlayerDeathParticleEffects;

    Rigidbody2D rb;

    [SerializeField]
    float turnSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (!mainGameManager.gameStarted)
        {
            rb.AddTorque(10, ForceMode2D.Force);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
                {
                    rb.AddTorque(turnSpeed, ForceMode2D.Force);
                }
                else
                {
                    rb.AddTorque(-turnSpeed, ForceMode2D.Force);
                }
            }
        }
    }

    void OnPlayerDestroyEffects()
    {
        Debug.Log("CAlled");
        Instantiate(onPlayerDeathParticleEffects,playerObject.transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ring")
        {
            Handheld.Vibrate();
            OnPlayerDestroyEffects();
            mainGameManager.GameOver();
            mainAudioManager.PlayPlayerDestroyAudio();
            Destroy(gameObject);
        }
    }

}
