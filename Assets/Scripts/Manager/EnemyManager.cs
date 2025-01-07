using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public  Player player; // Bu, düşmanın oyuncuyu takip etmesine yardımcı olur
    
    public Enemy enemyPrefab; // Bu, düşmanın örneğini temsil eder
    
    public List<Enemy> enemies; // Bu, düşmanların listesini tutar
    
    public Vector2 enemyCount; // Bu, düşman sayısını belirler

    public void RestartEnemyManager()
    {
        DeleteEnmies(); // Bu, düşmanları siler
        CreateEnemies(); // Bu, düşmanları oluşturur
    }

   

    private void CreateEnemies()
    {
        var randomEnemyCount = Random.Range(enemyCount.x, enemyCount.y); // Bu, rastgele bir düşman sayısı belirler
        for (int i = 0; i < randomEnemyCount; i++)
        {
            var enemyXpos = Random.Range(-3.45f, 3.51f); // Bu, düşmanın x konumunu rastgele bir değerle belirler
            var newEnemy = Instantiate(enemyPrefab); // Bu, yeni bir düşman örneği oluşturur
            newEnemy.transform.position = new Vector3(enemyXpos, 0, -2 + i * 1.5f); // Bu, düşmanın konumunu ayarlar
            enemies.Add(newEnemy); // Bu, yeni düşmanı düşmanlar listesine ekler
            newEnemy.StartEnemy(player); // Bu, düşmanın oyuncuyu takip etmesine yardımcı olur
        }
        
    }

    private void DeleteEnmies()
    {
        foreach (var enemy in enemies) // Bu, düşmanların listesindeki her düşman için bir döngü oluşturur
        {
            enemy.DeleteZs();
            Destroy(enemy.gameObject); // Bu, düşmanı yok eder
        }
        enemies.Clear(); // Bu, düşmanların listesini temizler
    }
    

    public void StopEnmies() // Bu, düşmanların hareketini durdurur
    {
        foreach (var enemy in enemies) // Bu, düşmanların listesindeki her düşman için bir döngü oluşturur
        {
            enemy.Stop(); // Bu, düşmanların hızını sıfırlar
        }
    }
    
}
