using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
	private static SoundsManager instance;
	public static SoundsManager Instance { get { return instance; } }
	public AudioSource soundEffect;
	public AudioSource soundMusic;
	public SoundType[] Sounds;
	public bool IsMute = false;
	public float Volume = 1f;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void Start()
	{
		SetVolume(0.5f);
		PlayMusic(global::Sounds.Music);
	}
	public void Mute(bool status)
	{
		IsMute = status;
	}
	public void SetVolume(float volume)
	{
		Volume = volume;
		soundEffect.volume = Volume;
		soundMusic.volume = Volume;
	}
	public void PlayMusic(Sounds sound)
	{
		if (IsMute)
		{
			return;
		}
		AudioClip clip = getSoundClip(sound);
		if (clip != null)
		{
			soundMusic.clip = clip;
			soundMusic.Play();
		}
	}
	public void Play(Sounds sound)
	{
		if (IsMute)
		{
			return;
		}
		AudioClip clip = getSoundClip(sound);
		if (clip != null)
		{
			soundEffect.PlayOneShot(clip);
		}
	}

	private AudioClip getSoundClip(Sounds sound)
	{
		SoundType itm = Array.Find(Sounds, item => item.soundType == sound);
		if (itm != null)
		{
			return itm.soundClip;
		}
		return null;
	}
}
[Serializable]
public class SoundType
{
	public Sounds soundType;
	public AudioClip soundClip;
}
public enum Sounds
{
	ButtonClick,
	Music,
	PlayerJump,
	PlayerDeath,
	LevelEnd,
	CollectKey,
	EnemyAttack,
	EnemyDeath,
}

