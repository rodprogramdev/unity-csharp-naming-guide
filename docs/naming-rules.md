
# C# Naming Rules for Unity Beginners

## 1. PascalCase

Capitalize the first letter of each word.

Use for:
- Classes
- Methods
- Properties
- Interfaces
- Enums and enum members
- Constants, following this guide's convention

Examples:

```csharp
public class PlayerController
{
    public int CurrentHealth { get; private set; }

    public void TakeDamage(int damageAmount)
    {
    }
}

public interface IDamageable
{
    void TakeDamage(int damageAmount);
}

public enum PlayerState
{
    Idle,
    Running,
    Jumping
}

private const int MaxHealth = 100;
```

## 2. camelCase

Start with a lowercase letter.

Use for local variables and method parameters.

```csharp
int currentHealth = 100;

void HealPlayer(int healAmount)
{
    currentHealth += healAmount;
}
```

## 3. Private Fields

This project recommends an underscore prefix for private
instance fields.

```csharp
[SerializeField] private float _moveSpeed = 5f;
private int _currentHealth;
```

The underscore is a team style choice, not a universal
C# requirement.

## 4. Unity Script Files

Match the filename to the primary MonoBehaviour class.

File: PlayerController.cs

```csharp
using UnityEngine;

public class PlayerController : MonoBehaviour
{
}
```

## 5. Meaningful Names

Prefer:
- currentHealth instead of x
- TakeDamage instead of DoThing
- isGrounded instead of flag
- damageAmount instead of d

Names should explain the purpose of a variable, method,
or class without requiring guesswork.

## 6. Unity-Specific Considerations

- A script filename and a GameObject name are different things.
- Unity does not require a single naming style for all
  GameObjects in the Hierarchy.
- Renaming serialized fields in an existing project can
  affect saved Inspector data. Use appropriate migration
  techniques, such as FormerlySerializedAs, when necessary.
- Consistency matters more than arguing over equally valid
  naming styles.

## Review Checklist

- [ ] Is the name meaningful?
- [ ] Is the capitalization correct?
- [ ] Does the script filename match its main class?
- [ ] Are private fields named consistently?
- [ ] Can another developer understand the identifier?
