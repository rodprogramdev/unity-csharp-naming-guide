```csharp
using UnityEngine;

// NAMING RULE: Class names use PascalCase.
// The file name must match the MonoBehaviour class name:
// PlayerController.cs
public class PlayerController : MonoBehaviour
{
    // UNITY: SerializeField exposes a private field in the Inspector.
    // NAMING RULE: Private fields use _camelCase in this guide.
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _startingHealth = 100;

    // NAMING RULE: Public properties use PascalCase.
    // The public getter allows other scripts to read health.
    // The private setter prevents other scripts from assigning it directly.
    public int CurrentHealth { get; private set; }

    // UNITY: Awake() runs when the component is initialized.
    // NAMING RULE: Unity lifecycle method names must match Unity's API.
    private void Awake()
    {
        // Initialize the player's health using the configured starting value.
        CurrentHealth = _startingHealth;
    }

    // UNITY: Update() runs once per frame while the component is enabled.
    private void Update()
    {
        // Delegate movement logic to a separate method.
        MovePlayer();
    }

    // NAMING RULE: Method names use PascalCase.
    // This private method handles the player's movement.
    private void MovePlayer()
    {
        // NAMING RULE: Local variables use camelCase.
        // Read the horizontal and vertical movement inputs.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Combine the input values into a 3D movement direction.
        // The Y value is zero because this example moves along the X and Z axes.
        Vector3 movement = new Vector3(
            horizontalInput,
            0f,
            verticalInput
        );

        // Limit the vector's magnitude to prevent faster diagonal movement.
        movement = Vector3.ClampMagnitude(movement, 1f);

        // UNITY: Time.deltaTime makes movement speed independent of frame rate.
        // Translate moves the GameObject using the calculated movement vector.
        transform.Translate(
            movement * (_moveSpeed * Time.deltaTime)
        );
    }

    // NAMING RULE: Public method names use PascalCase.
    // NAMING RULE: Method parameters use camelCase.
    // This method reduces health without allowing negative damage values.
    public void TakeDamage(int damageAmount)
    {
        // Ignore zero or negative damage.
        if (damageAmount <= 0)
        {
            return;
        }

        // Subtract the damage and prevent health from dropping below zero.
        // Mathf.Max returns whichever value is greater: 0 or the calculated health.
        CurrentHealth = Mathf.Max(
            0,
            CurrentHealth - damageAmount
        );
    }
}
```