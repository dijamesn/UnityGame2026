using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text moneyText;
    public Text livesText;
    public Text waveText;

    [Header("Turret Info Popup")]
    // Assign a UI Text (or TMP_Text) in the Inspector for the turret info popup.
    public Text turretInfoText;
    public float infoDisplayDuration = 2.5f;

    private Coroutine hideInfoCoroutine;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one UIManager in scene!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        if (turretInfoText != null)
            turretInfoText.gameObject.SetActive(false);
    }

    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
        livesText.text = "Lives: " + PlayerStats.Lives.ToString();
        waveText.text  = "Wave " + WaveSpawner.waveIndex.ToString();
    }

    // Call this when the player presses 1 or 2 to preview a turret
    public void ShowTurretInfo(TurretBlueprint blueprint)
    {
        if (turretInfoText == null || blueprint == null)
            return;

        turretInfoText.text = string.Format(
            "<b>{0}</b>\nCost: ${1}\n{2}",
            blueprint.turretName,
            blueprint.cost,
            blueprint.description
        );

        turretInfoText.gameObject.SetActive(true);

        // Cancel any existing hide timer and restart it
        if (hideInfoCoroutine != null)
            StopCoroutine(hideInfoCoroutine);

        hideInfoCoroutine = StartCoroutine(HideInfoAfterDelay());
    }

    private IEnumerator HideInfoAfterDelay()
    {
        yield return new WaitForSeconds(infoDisplayDuration);
        if (turretInfoText != null)
            turretInfoText.gameObject.SetActive(false);
    }
}
