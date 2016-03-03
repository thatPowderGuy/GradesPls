using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public abstract class Clickable : MonoBehaviour {

    public abstract void getClicked(Vector3 clickPosition);
}
