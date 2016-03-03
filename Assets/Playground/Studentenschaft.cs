using UnityEngine;
using System.Collections.Generic;

public class Studentenschaft : MonoBehaviour {

    public FontDatabase fontDatabase;

    private static Studentenschaft _instance;
    public static Studentenschaft instance
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
        studenten = new List<Student>();
        Student.fontDatabase = fontDatabase;
    }

    private List<Student> studenten;

    public void AddStudent(Student s)
    {
        studenten.Add(s);
    }
}
