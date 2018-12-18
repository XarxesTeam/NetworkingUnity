using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GAME_STATE
{
    _INIT = 0,
    _CONNECT,
    PLAY
}

public class GameLogic : MonoBehaviour {



    Texture2D init_texture = null;

    Texture2D conect_texture = null;
    private float connect_delay_time = 1.0f;
    private float timer = 0.0f;

    public GAME_STATE game_state;

    // Use this for initialization
    void Start ()
    {
        game_state = GAME_STATE._INIT;

        init_texture = new Texture2D(Screen.width, Screen.height);
        Color color = new Color(0.5f, 0.5f, 0.5f);
        var fillColorArray = init_texture.GetPixels();
        for (var i = 0; i < fillColorArray.Length; ++i)
        {
            fillColorArray[i] = color;
        }
        init_texture.SetPixels(fillColorArray);
        init_texture.Apply();

        conect_texture = new Texture2D(Screen.width, Screen.height);
        color = new Color(0.4f, 0.4f, 0.4f);
        fillColorArray = conect_texture.GetPixels();
        for (var i = 0; i < fillColorArray.Length; ++i)
        {
            fillColorArray[i] = color;
        }
        conect_texture.SetPixels(fillColorArray);
        conect_texture.Apply();
    }

    // Update is called once per frame
    void Update ()
    {
		if(game_state == GAME_STATE._CONNECT)
        {
            timer += Time.deltaTime;
            if(timer > connect_delay_time)
            {
                timer = 0.0f;
                game_state = GAME_STATE.PLAY;
            }
        }
	}

    private void OnGUI()
    {
        switch (game_state)
        {
            case GAME_STATE._INIT:
                {
                    GUI.depth = 1;
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), init_texture);

                    if (GUI.Button(new Rect(Screen.width * 0.5f - 200 * 0.5f, Screen.height * 0.55f, 200, 20), "Back to Character Selection"))
                    {
                        SceneManager.LoadScene("MainMenu");
                        Destroy(GameObject.FindGameObjectWithTag("NetworkManager"), 0.0f);
                    }
                }
                break;

            case GAME_STATE._CONNECT:
                {
                    GUI.depth = 1;
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), conect_texture);

                    GUI.depth = 0;
                    GUI.Label(new Rect(Screen.width * 0.5f - 150 * 0.5f, Screen.height * 0.45f, 150, 20), "Connecting...");
                }
                break;

            case GAME_STATE.PLAY:
                {

                }
                break;
        }
    }
}
