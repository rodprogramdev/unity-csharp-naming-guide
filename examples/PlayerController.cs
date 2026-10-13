
using UnityEngine;

/// <summary>
/// Demonstrates naming conventions for a Unity component.
/// File: PlayerController.cs
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _startingHealth = 100;

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _startingHealth;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(
            horizontalInput,
            0f,
            verticalInput
        );

        transform.Translate(
            movement * (_moveSpeed * Time.deltaTime)
        );
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth = Mathf.Max(
            0,
            CurrentHealth - damageAmount
        );
    }
}
