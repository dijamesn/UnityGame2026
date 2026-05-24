using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBuilder : MonoBehaviour
{
    public Camera playerCamera;
    public float buildRange = 100f;
    public LayerMask nodeMask;

    private BuildManager buildManager;
    private Node currentNode;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buildManager.SelectTurretToBuild(buildManager.standardTurret);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buildManager.SelectTurretToBuild(buildManager.missileLauncher);
        }

        UpdateNodeHighlight();

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            TryBuild();
        }
    }

    void UpdateNodeHighlight()
    {
        if (currentNode != null)
        {
            currentNode.ResetColor();
            currentNode = null;
        }

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * buildRange, Color.red);

        if (Physics.Raycast(ray, out hit, buildRange, nodeMask))
        {
            Node node = hit.collider.GetComponent<Node>();

            if (node == null)
                node = hit.collider.GetComponentInParent<Node>();

            if (node != null)
            {
                currentNode = node;
                currentNode.Highlight(buildManager.CanBuild, buildManager.HasMoney);
            }
        }
    }

    void TryBuild()
    {
        if (currentNode == null)
        {
            Debug.Log("No node hit."); //Need to add to ui
            return;
        }

        if (!buildManager.CanBuild)
        {
            Debug.Log("No turret selected."); //Need to add to ui
            return;
        }

        buildManager.BuildTurretOn(currentNode);
    }
}