using UnityEngine;
using System.Collections;

public class Stempelkissen : Clickable
{
    public GameObject image;
    public Stempel.stamps stamp;
    public Color color;

    public override bool getClicked(Vector3 clickPosition, Stempel stempel)
    {
        stempel.image = image;
        stempel.stamp = stamp;
        stempel.stampColor = color;
        return false;
    }
}
