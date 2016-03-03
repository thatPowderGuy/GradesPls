using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public abstract class Clickable : MonoBehaviour {

    //return true if stuff can be stamped onto this object.
    public abstract bool getClicked(Vector3 clickPosition, Stempel stempel);
}
