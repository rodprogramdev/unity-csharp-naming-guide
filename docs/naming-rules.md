# C# Naming Rules for Unity Beginners

A beginner-friendly reference for naming variables, methods, classes, and other identifiers in C# projects made with Unity.

This guide explains common C# naming conventions, Unity-specific considerations, and the naming preferences adopted by this project.

## 1. Understanding Naming Conventions

A naming convention is an agreed way of naming elements in source code.

Consistent naming helps developers understand code, recognize different types of elements, and collaborate more effectively.

Consider this example:

```csharp
int h = 100;
```

The name `h` does not explain what the value represents.

A clearer version is:

```csharp
int currentHealth = 100;
```

The second example communicates the variable's purpose more clearly.

### Rules, conventions, and recommendations

Not every naming convention is a language requirement.

This guide distinguishes between:

- **Common C# convention:** A widely used naming practice in C# development.
- **Project recommendation:** A style preference adopted by this guide.
- **Language requirement:** A rule imposed by C# syntax or compiler behavior.

Teams may establish their own conventions, but they should document and apply them consistently.

## 2. Quick Reference

| Code element | Recommended convention | Example |
|---|---|---|
| Namespace | PascalCase | `PintigLaro.Gameplay` |
| Class | PascalCase | `PlayerController` |
| Struct | PascalCase | `DamageInfo` |
| Interface | `I` + PascalCase | `IDamageable` |
| Enum type | PascalCase | `PlayerState` |
| Enum member | PascalCase | `Running` |
| Method | PascalCase | `TakeDamage()` |
| Property | PascalCase | `CurrentHealth` |
| Event | PascalCase | `HealthChanged` |
| Constant | PascalCase | `MaxHealth` |
| Local variable | camelCase | `currentHealth` |
| Method parameter | camelCase | `damageAmount` |
| Private field | `_camelCase` | `_currentHealth` |
| Generic type parameter | `T` or descriptive `T`-prefixed name | `TItem` |

**Important:** This guide recommends `_camelCase` for private fields. The leading underscore is a project style choice, not a C# language requirement.

Public fields are generally best avoided when a property or another encapsulated design is more appropriate. Unity serialization needs are discussed in Section 8.

## 3. PascalCase

### Rule

Use PascalCase for classes, structs, interfaces, enums, methods, and properties.

In PascalCase, each word begins with an uppercase letter.

### Good example

```csharp
public class PlayerController
{
    public int CurrentHealth { get; private set; }

    public void TakeDamage(int damageAmount)
    {
        // Damage logic goes here.
    }
}
```

### Avoid

```csharp
public class playercontroller
{
    public int currenthealth;

    public void takedamage(int damageamount)
    {
        // Damage logic goes here.
    }
}
```

### Why it matters

PascalCase makes types and members easier to recognize and follows common C# naming conventions.

### Unity application

Use PascalCase for `MonoBehaviour` and `ScriptableObject` class names.

```csharp
using UnityEngine;

public class EnemyController : MonoBehaviour
{
}
```

For a `MonoBehaviour` component script, use a matching filename:

`EnemyController.cs` → `EnemyController`

## 4. camelCase

### Rule

Use camelCase for local variables and method parameters.

The first word begins with a lowercase letter, while subsequent words begin with uppercase letters.

### Good example

```csharp
void HealPlayer(int healAmount)
{
    int remainingHealth = 50;
    remainingHealth += healAmount;
}
```

### Avoid

```csharp
void HealPlayer(int HealAmount)
{
    int RemainingHealth = 50;
    RemainingHealth += HealAmount;
}
```

### Unity application

Use descriptive camelCase names for temporary values, calculations, and input values.

```csharp
float horizontalInput = 0f;
float movementAmount = horizontalInput * 5f;
```

## 5. Private Fields: `_camelCase`

### Rule

This project recommends a leading underscore followed by camelCase for private fields.

### Good example

```csharp
private int _currentHealth;
private float _moveSpeed;
private bool _isGrounded;
```

### Avoid inconsistent naming

```csharp
private int currentHealth;
private float MoveSpeed;
private bool isGrounded;
```

The second example mixes styles instead of following this project's private-field convention.

### Why it matters

The leading underscore can help distinguish class-level fields from local variables and method parameters.

Remember that this is a style choice. Other C# projects may use private fields without an underscore.

## 6. Interfaces: `I` + PascalCase

### Rule

Start interface names with an uppercase `I`, followed by a PascalCase name.

### Example: `IDamageable.cs`

The following example demonstrates interface, method, and parameter naming conventions in C#.

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

#### Naming Conventions Demonstrated

| Code element | Convention | Explanation |
|---|---|---|
| `IDamageable` | `I` + PascalCase | Interface names begin with an uppercase `I`, followed by a PascalCase name. |
| `TakeDamage` | PascalCase | Method names begin with an uppercase letter, and each word starts with a capital letter. |
| `damageAmount` | camelCase | Parameter names begin with a lowercase letter, with subsequent words capitalized. |
| `///` | XML documentation comments | Three-slash comments document types, methods, and parameters. Compatible IDEs can display this information in tooltips. |

**Key takeaway:** Consistent naming helps developers recognize the purpose of an identifier and distinguish interfaces, methods, and parameters when reading code.

**Related example:** See [`examples/IDamageable.cs`](../examples/IDamageable.cs) for the standalone source file.

### Good example

```csharp
public interface IDamageable
{
    void TakeDamage(int damageAmount);
}
```

Other examples:

- `IInteractable`
- `ISaveable`
- `ICollectible`

### Avoid

```csharp
public interface Damageable
{
    void TakeDamage(int damageAmount);
}
```

### Unity application

Interfaces can describe capabilities shared by different types of game objects.

For example, a player, enemy, and destructible object could all implement `IDamageable` without inheriting from the same custom base class.

## 7. Enums and Enum Members

### Rule

Use PascalCase for both the enum type and its members.

### Good example

```csharp
public enum PlayerState
{
    Idle,
    Running,
    Jumping,
    Falling,
    Dead
}
```

### Avoid

```csharp
public enum player_state
{
    idle,
    RUNNING,
    jumping
}
```

### Unity application

Enums are useful for representing a limited set of states or options, such as movement states, game modes, and interaction types.

Choose names that clearly describe each state or option.

## 8. Constants and Unity Serialized Fields

### Constants

This project recommends PascalCase for named constants.

```csharp
private const int MaxHealth = 100;
private const float JumpForce = 8f;
```

C# teams may choose different styles for constants. Follow the convention documented by your project.

Use `const` for values that qualify as compile-time constants. Values that need to be configured through the Unity Inspector may be better represented by serialized fields.

### Unity serialized fields

Unity allows private fields to appear in the Inspector using the `SerializeField` attribute.

```csharp
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _startingHealth = 100;
}
```

This example follows the project's `_camelCase` convention while allowing Unity to serialize the fields.

### Important serialization consideration

Renaming a serialized field in an existing project can affect previously saved Inspector data.

When appropriate, use Unity's `FormerlySerializedAs` attribute to preserve values associated with an old field name during a rename.

Do not rename serialized fields casually in projects that already contain scenes or prefabs.

## 9. Methods and Parameters

### Rule

Use PascalCase for methods and camelCase for parameters.

Choose method names that describe an action or operation.

### Good example

```csharp
public void TakeDamage(int damageAmount)
{
    _currentHealth -= damageAmount;
}
```

### Avoid

```csharp
public void Do(int x)
{
    _currentHealth -= x;
}
```

The first example communicates the purpose of both the method and its parameter more clearly.

For Boolean-returning methods, names such as `CanJump()`, `IsGrounded()`, and `HasKey()` can communicate intent effectively.

## 10. Boolean Names

### Rule

Choose names that make true-or-false conditions easy to understand.

### Good examples

```csharp
private bool _isGrounded;
private bool _canJump;
private bool _hasKey;
```

For local variables:

```csharp
bool isAlive = _currentHealth > 0;
```

### Avoid

```csharp
private bool _ground;
private bool _jump;
private bool _key;
```

These shorter names do not clearly communicate whether they represent an object, an action, or a condition.

## 11. Events and Event Handlers

### Rule

Use PascalCase for event names and handler methods.

### Good example

```csharp
public event Action HealthChanged;

private void HandleHealthChanged()
{
    // Respond to the health change.
}
```

This example assumes the appropriate `System` namespace is imported for `Action`.

Names such as `OnHealthChanged` are also common, especially in Unity APIs. Choose a consistent approach for your own events and handlers.

## 12. Namespaces and Generic Type Parameters

### Namespaces

Use PascalCase for namespace segments.

```csharp
namespace PintigLaro.Gameplay
{
    public class PlayerController
    {
    }
}
```

Namespaces help organize larger projects and reduce naming conflicts.

### Generic type parameters

Use `T` for a simple generic type parameter or a descriptive `T`-prefixed name when it improves readability.

```csharp
public class Inventory<TItem>
{
}
```

Another example:

```csharp
public class Pair<TKey, TValue>
{
}
```

These names communicate the roles of the generic types.

## 13. Unity Script Files

### Rule

For a `MonoBehaviour` component script, make the filename match the primary component class.

**Filename:** `PlayerController.cs`

```csharp
using UnityEngine;

public class PlayerController : MonoBehaviour
{
}
```

This is the standard approach for Unity component scripts.

A GameObject that uses this component does not have to be named `PlayerController`. The script filename, class name, and GameObject name serve different purposes.

## 14. Unity-Specific Considerations

When applying naming conventions in Unity, remember the following:

- **Script filenames and GameObject names are different.** A script such as `PlayerController.cs` normally matches its primary `MonoBehaviour` class, while the GameObject using the component can have a different name.
- **GameObjects do not have one universally required naming style.** This guide recommends descriptive names such as `Player`, `EnemySpawner`, and `HealthBar`.
- **Serialized fields require care when renamed.** Consider `FormerlySerializedAs` when appropriate to preserve existing serialized values.
- **Consistency matters.** Teams can adopt different naming styles, provided their conventions are clear and consistently applied.
- **Naming is only one part of code quality.** A correctly named class can still have too many responsibilities or unclear behavior.
- **C# identifier naming and Unity asset naming are separate concerns.** Document asset conventions independently when needed.

### Example asset names

```text
PlayerController.cs
PlayerCharacter.prefab
MainMenu.unity
HealthBar.mat
```

These are example project conventions, not universal Unity requirements.

## 15. Meaningful Names

Choose names that communicate purpose without requiring guesswork.

| Avoid | Prefer |
|---|---|
| `x` | `currentHealth` |
| `DoThing()` | `TakeDamage()` |
| `flag` | `isGrounded` |
| `d` | `damageAmount` |
| `tmp` | `temporaryTarget`, when that is its purpose |

These are illustrative examples, not absolute rules. Short names can be appropriate when their meaning is obvious in a small, familiar context.

Prefer clarity over unnecessary length.

## 16. Additional Tips

1. **Be consistent.** Follow the conventions already established in your project unless there is a good reason to change them.
2. **Prefer clarity over cleverness.** A descriptive name is usually more helpful than an abbreviation only its author understands.
3. **Use names that reflect intent.** `CanJump()` communicates a condition more clearly than `Check()`.
4. **Avoid unnecessary repetition.** Inside `PlayerController`, a method named `MovePlayerController()` may be unnecessarily repetitive if `Move()` already communicates the intended action.
5. **Review names as your code evolves.** A name that made sense during prototyping may become misleading when a feature changes.
6. **Treat conventions as a team agreement.** Document the chosen style so contributors can follow it without guessing.
7. **Do not confuse naming style with correctness.** A well-named variable does not guarantee that the code behaves correctly.

## 17. Review Checklist

Before committing a Unity C# script, ask yourself:

- [ ] Is each name meaningful and descriptive?
- [ ] Is the capitalization correct for the identifier type?
- [ ] Does the script filename match its primary `MonoBehaviour` class, where applicable?
- [ ] Do private fields follow the project's `_camelCase` convention?
- [ ] Do interfaces use the `I` prefix?
- [ ] Are Boolean names clear about the condition they represent?
- [ ] Have serialized field renames been handled carefully?
- [ ] Can another developer understand each identifier without guessing?
- [ ] Are the names consistent with the rest of the project?

## 18. Practice and Further Learning

Use these rules alongside the example scripts in the repository's `examples` folder.

For additional practice:

1. Find unclear names in a small Unity script.
2. Rewrite them using the recommended conventions.
3. Explain why each new name is clearer.
4. Compare your solution with an exercise answer key.
5. Use the Unity Editor naming helper to check the naming patterns it supports.

The helper is a learning aid, not a complete C# compiler or static analyzer. Passing its checks does not guarantee that every naming convention or C# rule has been followed.

## 19. References

Consult these sources when checking or extending the recommendations in this guide.

- [Microsoft: C# identifier naming rules and conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names)
- [Microsoft: C# coding conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Unity: Naming and code style tips for C# scripting](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)
- [Unity: SerializeField](https://docs.unity3d.com/ScriptReference/SerializeField.html)
- [Unity: FormerlySerializedAsAttribute](https://docs.unity3d.com/ScriptReference/Serialization.FormerlySerializedAsAttribute.html)

---

**Project philosophy:** Consistent naming improves readability, collaboration, and maintainability. Choose meaningful names, follow an agreed convention, and understand the reasons behind your decisions.
