using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Font Database", menuName = "Font Database")]
public class FontDatabase : ScriptableObject {

    public List<Font> typeFaces = new List<Font>();

    public Font GetRandom()
    {
        return typeFaces[Random.Range(0, typeFaces.Count)];
    }
}
