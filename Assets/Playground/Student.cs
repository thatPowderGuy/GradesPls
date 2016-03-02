using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct Student {

    [SerializeField]
    private string firstName;

    [SerializeField]
    private string lastName;

    [SerializeField]
    private string matrikelNummer;

    [SerializeField]
    private float intelligence;

    [SerializeField]
    private Font typeface;

    public Student GenerateNewPunnyStudent(FontDatabase fontDatabase)
    {
        string[] fullName = NameDatabase.GetFirstAndLastName();

        return new Student {
            firstName = fullName[0],
            lastName = fullName[1],
            matrikelNummer = "0" + UnityEngine.Random.Range(3600000, 3699999),
            intelligence = UnityEngine.Random.Range(0f,1f),
            typeface = fontDatabase.GetRandom()};
    }

    public string FirstName()
    {
        return firstName;
    }

    public string LastName()
    {
        return lastName;
    }

    public string MatrikelNummer()
    {
        return matrikelNummer;
    }

    public float Intelligence()
    {
        return intelligence;
    }

    public Font Typeface()
    {
        return typeface;
    }
}
