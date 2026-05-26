using UnityEngine;

// From Brackeys — extended with display info
[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    [Header("Display Info")]
    public string turretName = "Turret";
    [TextArea]
    public string description = "No description.";
}
