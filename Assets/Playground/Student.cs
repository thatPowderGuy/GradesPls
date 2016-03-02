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
    private float intelligence;

    public Student GenerateNewPunnyStudent()
    {
        string[] fullName = NameDatabase.GetFirstAndLastName();

        return new Student {
            firstName = fullName[0] ,
            lastName = fullName[1],
            intelligence = UnityEngine.Random.Range(0f,1f)};
    }

    public string FirstName()
    {
        return firstName;
    }

    public string LastName()
    {
        return lastName;
    }

    public float Intelligence()
    {
        return intelligence;
    }
}
