using UnityEngine;

public class LoseLives : MonoBehaviour
{
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerStats.Lives--;
            Destroy(other.gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
{
    Debug.Log("Triggered by: " + other.name);
    PlayerStats.Lives--;
}
}