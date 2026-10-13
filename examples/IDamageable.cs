```csharp
/// <summary>
/// Defines a contract for objects that can receive damage.
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// Applies damage to the implementing object.
    /// </summary>
    /// <param name="damageAmount">The amount of damage to apply.</param>
    void TakeDamage(int damageAmount);
}
```