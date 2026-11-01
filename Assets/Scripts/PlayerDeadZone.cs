using System;
using UnityEngine;

public class PlayerDeadZone : MonoBehaviour
{

    public static event Action<int> OnProjectileHit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        switch (tag)
        {
            case "Projectile1":
                OnProjectileHit?.Invoke(10);
                break;
            case "Projectile2":
                OnProjectileHit?.Invoke(20);
                break;
            case "Projectile3":
                OnProjectileHit?.Invoke(50);
                break;
            default:
                break;

        }
        collision.gameObject.SetActive(false);
    }

    public static void ProjectileHit(int amount) { OnProjectileHit?.Invoke(amount);}
}
