using UnityEngine;
using System.Collections;

public class PauseEsc : MonoBehaviour 
{
	public bool paused = false;
	public GameObject panel;
	// Use this for initialization
	void Start () 
	{
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (!paused) 
			{
				Time.timeScale = 0;
				paused = true;
				panel.SetActive (true);
			} 
			else 
			{
				Time.timeScale = 1;
				paused = false;
				panel.SetActive (false);
			}
		}
	}
}
