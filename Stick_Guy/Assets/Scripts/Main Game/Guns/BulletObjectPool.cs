using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    [SerializeField]
    private BulletScript bulletPrefab;

    private Queue<BulletScript> bulletQ = new Queue<BulletScript>();

    public static BulletObjectPool Instance { get; private set; }

    // Singleton implementation (Not good for switching levels)
    private void Awake()
    {
        Instance = this;
    }

    public BulletScript Get()
    {
        if (bulletQ.Count == 0)
        {
            AddShots(1);
        }

        return bulletQ.Dequeue();
    }

    private void AddShots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            BulletScript newBullet = Instantiate(bulletPrefab);
            newBullet.gameObject.SetActive(false);
            bulletQ.Enqueue(newBullet);
        }
    }

    public void ReturnToPool(BulletScript bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletQ.Enqueue(bullet);
    }


}
