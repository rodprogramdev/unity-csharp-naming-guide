
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class UnityNamingHelperWindow : EditorWindow
{
    private enum NamingRule
    {
        PascalCase,
        CamelCase,
        PrivateField,
        InterfaceName,
        Constant
    }

    private string _candidateName = "playerController";
    private NamingRule _selectedRule = NamingRule.PascalCase;
    private string _resultMessage = "Enter a name and select Check Name.";
    private MessageType _resultType = MessageType.Info;

    [MenuItem("Tools/Naming Guide/Naming Helper")]
    public static void OpenWindow()
    {
        GetWindow<UnityNamingHelperWindow>("Naming Helper");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField(
            "Unity C# Naming Helper",
            EditorStyles.boldLabel
        );

        EditorGUILayout.HelpBox(
            "Check an identifier against a selected naming pattern. " +
            "This is a learning aid, not a complete C# analyzer.",
            MessageType.Info
        );

        _selectedRule = (NamingRule)EditorGUILayout.EnumPopup(
            "Naming Rule",
            _selectedRule
        );

        _candidateName = EditorGUILayout.TextField(
            "Name to Check",
            _candidateName
        );

        if (GUILayout.Button("Check Name"))
        {
            ValidateCandidate();
        }

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox(
            _resultMessage,
            _resultType
        );
    }

    private void ValidateCandidate()
    {
        string name = _candidateName == null
            ? string.Empty
            : _candidateName.Trim();

        if (string.IsNullOrEmpty(name))
        {
            SetResult(
                "Enter a name before checking it.",
                MessageType.Warning
            );
            return;
        }

        bool isValid = false;
        string expectedExample = string.Empty;

        switch (_selectedRule)
        {
            case NamingRule.PascalCase:
                isValid = Regex.IsMatch(
                    name, @"^[A-Z][A-Za-z0-9]*$"
                );
                expectedExample = "PlayerController";
                break;

            case NamingRule.CamelCase:
                isValid = Regex.IsMatch(
                    name, @"^[a-z][A-Za-z0-9]*$"
                );
                expectedExample = "currentHealth";
                break;

            case NamingRule.PrivateField:
                isValid = Regex.IsMatch(
                    name, @"^_[a-z][A-Za-z0-9]*$"
                );
                expectedExample = "_currentHealth";
                break;

            case NamingRule.InterfaceName:
                isValid = Regex.IsMatch(
                    name, @"^I[A-Z][A-Za-z0-9]*$"
                );
                expectedExample = "IDamageable";
                break;

            case NamingRule.Constant:
                isValid = Regex.IsMatch(
                    name, @"^[A-Z][A-Za-z0-9]*$"
                );
                expectedExample = "MaxHealth";
                break;
        }

        if (isValid)
        {
            SetResult(
                "'" + name + "' matches the selected pattern.",
                MessageType.Info
            );
        }
        else
        {
            SetResult(
                "'" + name + "' does not match the selected pattern. " +
                "Example: " + expectedExample,
                MessageType.Warning
            );
        }
    }

    private void SetResult(
        string message,
        MessageType messageType
    )
    {
        _resultMessage = message;
        _resultType = messageType;
        Repaint();
    }
}
