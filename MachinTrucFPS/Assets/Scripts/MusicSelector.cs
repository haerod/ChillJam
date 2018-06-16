using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour {
	public AudioClip[] musics;
	public AudioClip[] beats;
	[Space]
	[SerializeField] private int selected;
	private AudioSource musicSource;
	private AudioSource beatSource;

	void Start()
	{
		beatSource = GetComponent<AudioSource>();
		musicSource = transform.GetChild(1).GetComponent<AudioSource>();
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
			ChangeMusic(selected);
			break;
			case "é":
			selected = 1;
			ChangeMusic(selected);
			break;
			case "\"":
			selected = 2;
			ChangeMusic(selected);
			break;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
			{
				selected++;
				if(selected > 2) selected = 0;  
				ChangeMusic(selected);
			}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
		{
			selected--;
			if(selected < 0) selected = 2;
			ChangeMusic(selected);
		}
		
	}

	void ChangeMusic(int _selected)
	{
		musicSource.clip = musics[_selected];
		beatSource.clip = musics[_selected];
		musicSource.Play();
	}
}
