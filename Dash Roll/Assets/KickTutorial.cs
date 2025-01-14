using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickTutorial : MonoBehaviour
{
    bool inContactWithPlayer;
    void Start()
    {
        
    }

    private void Update()
    {
        if (inContactWithPlayer)
        {
            if (PlayerInput.DashRollPressed())
            {
                Time.timeScale = 0.33f;
            }

            if (PlayerInput.AttackPressed())
            {
                Time.timeScale = 1;
                Invoke("ResetDashCD", .1f);
            }
        }
    }

    void ResetDashCD()
    {
        Player.playerScript.SetDashCooldown(5);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 1)
        {
            inContactWithPlayer = true;
            Invoke("ResetDashCD", .1f);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 1)
        {
            Time.timeScale = 1;
            inContactWithPlayer = false;
        }
    }
}
