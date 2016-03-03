using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class AufgabenSeite : MonoBehaviour {

    public Aufgabenstellung aufgabenStellung;
    public Text aufgabePunkte, loesungHeader;
    public RectTransform aufgabenText { get; set; }
    public RawImage divider;
    public GameObject loesungen;
}
