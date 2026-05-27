using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public string turretName = "Turret";
    [TextArea]
    public string description = "No description.";
}