using UnityEngine;
using System.Collections.Generic;

public class FontDatabase : ScriptableObject {

    public List<Font> typeFaces = new List<Font>();

    public Font GetRandom()
    {
        return typeFaces[Random.Range(0, typeFaces.Count)];
    }
}
