using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SaveManager : MonoBehaviour
{

    private void Start()
    {
        //GameObject player = GameObject.Find("monkeyGuy");
        GameObject player = GameObject.FindObjectOfType<scr_Player>().gameObject;
        if (PlayerPrefs.HasKey("playerPosX"))
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("playerPosX"), PlayerPrefs.GetFloat("playerPosY"), player.transform.position.z);
        }
    }

    public void SavePosition()
    {
        Vector3 playerPosition = GameObject.FindObjectOfType<scr_Player>().gameObject.transform.position;

        PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
