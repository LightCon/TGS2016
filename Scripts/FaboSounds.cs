using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class FaboSounds : MonoBehaviour {

	public AudioClip[] fabottySounds;

	private AudioSource fabo_AudioSource;

	public GameObject fabotty;

	// Use this for initialization
	void OnTriggerStay (Collider other) {
		
		fabo_AudioSource = fabotty.GetComponent<AudioSource>();
		while (other.gameObject.tag == "PlayerRange" && !fabo_AudioSource.isPlaying) 
		{
			int rando = Random.Range (1, 8);
			fabo_AudioSource.clip = fabottySounds[rando];
			Debug.Log (rando);
			fabo_AudioSource.Play ();

		}

	
	}
}
