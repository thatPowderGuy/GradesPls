using UnityEngine;
using System.Collections;

public class PrefabHolder : MonoBehaviour {

    private static PrefabHolder _instance;
	public static PrefabHolder instance
    {
        set
        {
            if (null == _instance)
                _instance = value;
        }
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public GameObject klausurPrefab;
}
