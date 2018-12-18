using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour {

    bool intro = true;

    public int selectedGridIndex = 0;
    public string[] playerNames = new string[] { "Boy", "Girl", "Robot" };
    public short playerPrefabIndex;

    Camera camera;
    public Transform main_point;
    public Transform select_point;

    private int index_prefab = -1;
    public GameObject boy_prefab;
    public GameObject girl_prefab;
    public GameObject robot_prefab;


    private GUIStyle title_style;

    // Use this for initialization
    void Start ()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        girl_prefab.SetActive(false);
        boy_prefab.SetActive(false);
        robot_prefab.SetActive(false);

        title_style = new GUIStyle("label");
        title_style.fontSize = 70;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (intro == false)
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, select_point.position, Time.deltaTime);
        }
        else
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, main_point.position, Time.deltaTime);
        }
    }

    private void OnGUI()
    {
        if (intro)
        {
            GUI.Label(new Rect(Screen.width * 0.5f - 380 * 0.5f, Screen.height * 0.2f, 400, 100), "Fight Game", title_style);

            if (GUI.Button(new Rect(Screen.width * 0.5f - 150 * 0.5f, Screen.height * 0.6f, 150, 30), "Play"))
            {
                if(index_prefab != -1)
                {
                    GetComponent<SceneTransferMain>()._prefab_index = index_prefab;
                    GetComponent<SceneTransferMain>().StartGame();
                }
            }

            if (GUI.Button(new Rect(Screen.width * 0.5f - 150 * 0.5f,Screen.height* 0.7f,150,30),"Select Character"))
            {
                intro = false;
            }

            if (GUI.Button(new Rect(Screen.width * 0.5f - 150 * 0.5f, Screen.height * 0.8f, 150, 30), "Exit"))
            {
                Application.Quit();
            }

        }
        else
        {
            if (GUI.Button(new Rect(Screen.width * 0.2f - 150 * 0.5f, Screen.height * 0.7f, 150, 30), " Boy"))
            {
                intro = true;
                boy_prefab.SetActive(true);
                robot_prefab.SetActive(false);
                girl_prefab.SetActive(false);

                index_prefab = 0;
            }

            if (GUI.Button(new Rect(Screen.width * 0.5f - 150 * 0.5f, Screen.height * 0.7f, 150, 30), "Girl"))
            {
                intro = true;
                girl_prefab.SetActive(true);
                boy_prefab.SetActive(false);
                robot_prefab.SetActive(false);

                index_prefab = 1;
            }

            if (GUI.Button(new Rect(Screen.width * 0.8f - 150 * 0.5f, Screen.height * 0.7f, 150, 30), "Robot"))
            {
                intro = true;
                robot_prefab.SetActive(true);
                girl_prefab.SetActive(false);
                boy_prefab.SetActive(false);

                index_prefab = 2;
            }

            /*selectedGridIndex = GUI.SelectionGrid(new Rect(Screen.width - 200, 10, 200, 50), selectedGridIndex, playerNames, 3);
            playerPrefabIndex = (short)(selectedGridIndex + 1);*/

            if (GUI.Button(new Rect(Screen.width * 0.5f - 150 * 0.5f, Screen.height * 0.8f, 150, 30), "Done"))
            {
                intro = true;

            }
        }
    }
}
