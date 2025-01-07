using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector; // Bu, oyuncunun oyun yöneticisine erişmesine yardımcı olur
    
    private float baseSpeed = 2f;
    private float runMultiplier = 2.5f;

    public bool isAppleCollected; // Bu, oyuncunun bir elma topladığını belirlemek için kullanılır
    
    public Rigidbody _rb;
    
    private bool _isCharacterWalking;
    public Animator animator;
    
    public void RestartPlayer() // Bu, oyuncuyu yeniden başlatır
    {
        gameObject.SetActive(true); // Bu, oyuncuyu etkinleştirir
        _rb = GetComponent<Rigidbody>();
        _rb.position = new Vector3(0, 0, -6); // Bu, oyuncunun konumunu sıfırlar
        isAppleCollected = false; // Bu, oyuncunun bir elma topladığını sıfırlar
    }

    private void OnTriggerEnter(Collider other) // Bu, oyuncu bir şeyle çarpıştığında çağrılan bir geri arama işlevidir
    {
        if (other.tag == "Collectable") // Bu, oyuncu bir toplanabilir nesneyle çarpıştığında çağrılır
        {
            Debug.Log("You collected an apple!");
            Destroy(other.gameObject); // Toplanabilir nesneyi yok eder
            gameDirector.levelManager.AppleCollected(); // Oyuncunun bir elma topladığını belirtir
            isAppleCollected = true; // Oyuncunun bir elma topladığını belirtir
        }

        if (other.tag == "Door" && isAppleCollected) // Bu, oyuncu bir kapıyla çarpıştığında ve bir elma topladığında çağrılır
        {
            Debug.Log("You win!");
            gameDirector.LevelCompleted(); // Oyuncunun kazandığını belirtir
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.tag == "Enemy") // Bu, oyuncu bir düşmanla çarpıştığında çağrılır
        {
            Debug.Log("You died!");
            gameObject.SetActive(false); // Oyuncuyu devre dışı bırakır
        }
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var direction = Vector3.zero;
        float speed = baseSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= runMultiplier;
            SetWalkAnimationSpeed(2.5f);
        }else
        {
            SetWalkAnimationSpeed(1f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        
        if (direction.magnitude < .1f)
        {
            TriggerIdleAnimation();
        }
        else
        {
            TriggerWalkAnimation();
        }
        
        transform.LookAt(transform.position + direction);
        _rb.linearVelocity = direction.normalized * speed;
    }

    void TriggerWalkAnimation()
    {
        if (!_isCharacterWalking)
        {
            animator.SetTrigger("Walk");
            _isCharacterWalking = true;
        }
    }

    void TriggerIdleAnimation()
    {
        if (_isCharacterWalking)
        {
            animator.SetTrigger("Idle");
            _isCharacterWalking = false;
        }
    }
    
    void SetWalkAnimationSpeed(float speed)
    {
        animator.SetFloat("WalkSpeedMultiplayer", speed);
    }
    
}