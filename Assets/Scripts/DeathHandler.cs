using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanavs;

    private void Start()
    {
        gameOverCanavs.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanavs.enabled = true;
        Time.timeScale = 0; //stops time so cursor doesn't fight with controlling camera/being a cursor
        FindObjectOfType<WeaponSwitcher>().enabled = false; //so no weapons switch on death
        Cursor.lockState = CursorLockMode.None; //so the player can "hit escape" to enable the cursor
        Cursor.visible = true; // so you can see the cursor
    }
}
