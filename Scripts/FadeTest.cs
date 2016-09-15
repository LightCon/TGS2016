using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeTest : MonoBehaviour {

    public enum FADE_MODE
    {
        NULL = -1,
        FADE_IN,
        FADE_OUT,
        NUM
    }

    public FADE_MODE fade_mode;

    public Image FadeImage;

    [SerializeField]
    private Color _fadeColor;

    [SerializeField]
    private float fadeTime;

    public float FadeTime
    {
        get { return fadeTime; }
        set
        {
            if (value < 0) { fadeTime = 0; }
            else { fadeTime = value; }
        }
    }
    [SerializeField]
    private bool _fadeStart = false;

    void Start()
    {
        _fadeColor = FadeImage.color;
    }

    public void FadeOut()
    {
        FadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, 1);
        fade_mode = FADE_MODE.FADE_OUT;
        _fadeStart = true;
        Debug.Log("FadeOut!");
    }

    public void FadeIn()
    {
        FadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, 0);
        fade_mode = FADE_MODE.FADE_IN;
        _fadeStart = true;

        Debug.Log("FadeIn!");
    }

    void Update()
    {

        if (FadeImage.color.a < 0)
        {
            FadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, 0);

            _fadeStart = false;
        }
        else if (FadeImage.color.a > 1)
        {
            FadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, 1);

            _fadeStart = false;
        }

        if(_fadeStart)
        {
            if (fade_mode == FADE_MODE.FADE_OUT)
            {
                float fadeSpeed = Time.deltaTime / FadeTime;
                FadeImage.color -= new Color(0, 0, 0, fadeSpeed);
                
            }
            else if (fade_mode == FADE_MODE.FADE_IN)
            {
                float fadeSpeed = Time.deltaTime / FadeTime;
                FadeImage.color += new Color(0, 0, 0, fadeSpeed);

            }
        }

    }

}
