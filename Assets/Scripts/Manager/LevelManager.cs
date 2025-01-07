using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public GameObject door; // Bu, kapıyı temsil eder
    public GameObject collectablePrefab; // Bu, toplanabilir nesnenin örneğini temsil eder
    public List<GameObject> collectables; // Bu, toplanabilir nesnelerin listesini tutar
    
    public void RestartLevel() // Bu, seviyeyi yeniden başlatır
    {
        DeactivateDoor();
        RandomizeDoorPosition();
        DeleteCollectables();
        CreateCollectables();
    }

    private void DeleteCollectables()
    {
        foreach (GameObject c in collectables)
        {
            Destroy(c.gameObject); // Bu, toplanabilir nesneyi yok eder
        }
        collectables.Clear(); // Bu, toplanabilir nesneler listesini temizler
    }

    private void CreateCollectables()
    {
        var newCollectable = Instantiate(collectablePrefab); // Bu, yeni bir toplanabilir nesne örneği oluşturur
        newCollectable.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), 0, 7); // This sets the position of the collectable
        collectables.Add(newCollectable); // Bu, yeni toplanabilir nesneyi toplanabilir nesneler listesine ekler
    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position; // Bu, kapının konumunu alır
        pos.x = Random.Range(-4f, 4f); // Bu, kapıyı rastgele bir konuma yerleştirir
        door.transform.position = pos; // Bu, kapının konumunu günceller
    }

    private void DeactivateDoor()
    {
        door.SetActive(false); // Bu, kapıyı devre dışı bırakır
    }

    public void AppleCollected() // Bu, bir elma toplandığında çağrılır
    {
        door.SetActive(true); // Bu, kapıyı etkinleştirir
    }
    
}
