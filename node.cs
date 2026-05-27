using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor = Color.green;
    public Color notEnoughMoneyColor = Color.red;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    public TurretBlueprint turretBlueprint;

    private Renderer rend;
    private Color startColor;

    // Pinkish colour used when a non-standard turret is selected on this node
    private static readonly Color otherTurretColor = new Color(1f, 0.4f, 0.7f);

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void Highlight(bool canBuildHere, bool hasMoney)
    {
        if (turret != null)
        {
            // Show cyan for the standard turret, pink for any other
            BuildManager bm = BuildManager.instance;
            bool isStandard = bm == null || bm.GetTurretToBuild() == null || bm.GetTurretToBuild() == bm.standardTurret;
            rend.material.color = isStandard ? Color.cyan : otherTurretColor;
            return;
        }

        if (!canBuildHere)
        {
            rend.material.color = startColor;
            return;
        }

        rend.material.color = hasMoney ? hoverColor : notEnoughMoneyColor;
    }

    public void ResetColor()
    {
        rend.material.color = startColor;
    }
}
