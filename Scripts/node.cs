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
            rend.material.color = Color.cyan;
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