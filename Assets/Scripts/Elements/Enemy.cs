using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
   private Player _player; // Bu, düşmanın oyuncuyu takip etmesine yardımcı olur
   public float speed = 2f; // Bu, düşmanın hızını belirler
   private Rigidbody _rb;
   public NavMeshAgent navMeshAgent;
   private Animator _animator;
   public Transform zPrefab;
   
   private bool _isWalking;

   private Transform _z1;
   private Transform _z2;
   
   public void StartEnemy(Player player)
   {
      _player = player; // Bu, oyuncuyu düşmana atar
      _rb = GetComponent<Rigidbody>();
      _animator = GetComponentInChildren<Animator>(); 
      transform.Rotate(0, Random.Range(-180, 180), 0); // Bu, düşmanın yönünü rastgele bir değerle döndürür
      CreateAndAnimateZPrefab();
   }

   private void CreateAndAnimateZPrefab()
   {
      // İlk Z prefabini oluştur ve animasyon başlat
      _z1 = Instantiate(zPrefab);
      _z1.position = transform.position + Vector3.up * 2.3f; // Bu, Z'nin konumunu ayarlar
      _z1.localScale = Vector3.zero;
      _z1.DOMoveY(_z1.position.y + 1, 1f)
         .SetEase(Ease.Linear)
         .SetLoops(-1, LoopType.Restart); // Bu, Z'nin yukarı ve aşağı hareketini başlatır
      _z1.DOScale(1, 1f)
         .SetLoops(-1, LoopType.Restart); // Bu, Z'nin büyüme ve küçülme animasyonunu başlatır

      // İkinci Z prefabini oluştur ve animasyon başlat
      _z2 = Instantiate(zPrefab);
      _z2.position = transform.position + Vector3.up * 2; // Bu, Z'nin konumunu ayarlar
      _z2.localScale = Vector3.zero;
      _z2.DOMoveY(_z2.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetDelay(.5f); // Bu, Z'nin yukarı ve aşağı hareketini başlatır (gecikmeli)
      _z2.DOScale(1, 1f).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear).SetDelay(.5f); // Bu, Z'nin büyüme ve küçülme animasyonunu başlatır
   }


   public void Update()
   {
      if (_player.isAppleCollected)
      {
         navMeshAgent.SetDestination(_player.transform.position); // This helps the enemy follow the player

         if (!_isWalking)
         {
            _isWalking = true;
            _animator.SetTrigger("Walk");
            _z1.DOKill();
            _z2.DOKill();
            Destroy(_z1.gameObject);
            Destroy(_z2.gameObject);
         } 
      }
   }

   public void Stop()
   {
      navMeshAgent.speed = 0; // Bu, düşmanın hızını sıfırlar
      _animator.SetTrigger("Idle");
   }
   
   public void DeleteZs()
   {
      if (_z1 != null) // Bu, Z1'in var olup olmadığını kontrol eder
      {
         _z1.DOKill();
         Destroy(_z1.gameObject);
      }
      if (_z2 != null)
      {
         _z2.DOKill();
         Destroy(_z2.gameObject);
      }
   }
   
}
