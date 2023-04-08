using UnityEngine;

public class Obstacale : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet")
        {
            Player.onTakeDamage.Invoke();
        }
    }
}
