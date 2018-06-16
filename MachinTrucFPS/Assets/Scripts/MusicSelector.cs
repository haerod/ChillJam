using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Musics
{
    public AudioClip song;
    public int bpm;
    public int bpmDivider;
}

public class MusicSelector : MonoBehaviour {
    public Musics[] musics;
	[Space]
	[SerializeField] private int selected;
    private AudioSource musicSource;

    public float dspTime;
    public float bpm;
    public float bpmDivider;

    void Start()
	{
		musicSource = transform.GetChild(1).GetComponent<AudioSource>();
        ChangeMusic();
	}

	void Update()
	{
		CheckInput();
	}

	void CheckInput()
	{
		var input = Input.inputString;
		switch(input)
		{
			case "&":
			    selected = 0;
			    ChangeMusic();
			    break;
			case "é":
			    selected = 1;
			    ChangeMusic();
			    break;
			case "\"":
			    selected = 2;
			    ChangeMusic();
			    break;
            case "'":
                selected = 3;
                ChangeMusic();
                break;
        }
		if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
			{
				selected++;
				if(selected > 3) selected = 0;  
				ChangeMusic();
			}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
		{
			selected--;
			if(selected < 0) selected = 3;
			ChangeMusic();
		}
		
	}

	void ChangeMusic()
	{
		musicSource.clip = musics[selected].song;
        bpm = musics[selected].bpm;
        bpmDivider = musics[selected].bpmDivider;
        dspTime = (float)AudioSettings.dspTime;
        musicSource.Play();
	}
}
