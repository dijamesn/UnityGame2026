using UnityEngine;

public class Shop : MonoBehaviour
{
    public BuildManager buildManager;

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(buildManager.standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(buildManager.missileLauncher);
    }
}