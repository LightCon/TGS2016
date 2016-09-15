using UnityEngine;
using System.Collections;

public class Sound_controller : MonoBehaviour
{

    //サウンドを取得
    public AudioClip sound01;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("おとととととととととととととっとと");
        //AudioClip clip = gameObject.GetComponent<AudioSource>().clip;
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound01);
        Destroy(gameObject, 1.0f);
    }
}