using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    public bool HasMoney
    {
        get { return turretToBuild != null && PlayerStats.Money >= turretToBuild.cost; }
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void BuildTurretOn(Node node)
    {
        if (turretToBuild == null)
            return;

        if (node.turret != null)
        {
            Debug.Log("Turret already built here.");
            return;
        }

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        node.turretBlueprint = turretToBuild;

        if (buildEffect != null)
        {
            GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);
        }

        Debug.Log("Built turret on " + node.name);
    }
}