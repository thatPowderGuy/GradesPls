using UnityEngine;
using System.Collections;

public class InkpadObj : MonoBehaviour {

    public Color inkpadColor;

    public SpriteRenderer pad;
    public SpriteRenderer img;
    public Stempelkissen script;

	// Use this for initialization
	void Start () {
        script.color = inkpadColor;
        img.color = inkpadColor;
	}
}
