using System;
using System.Reflection;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class FontSizeCustomizer : MonoBehaviour
{
    TMP_StyleSheet styleSheet => TMP_Settings.defaultStyleSheet;

    [SerializeField] string styleName;

    public static Action<string> UpdatedTheTextStyle;

    public void ChangeFontSize(float fontSize)
    {
        TMP_Style style = styleSheet.GetStyle(styleName);

        if (style == null)
        {
            Debug.Log($"No style with name {styleName} found in the default stylesheet. Check for spelling?");
            return;
        }

        Regex regex = new Regex(@"<size=\d+>");

        string modifiedOpeningDefinition = regex.Replace(style.styleOpeningDefinition, $"<size={fontSize}>"); 

        FieldInfo openingDefinitionField = typeof(TMP_Style).GetField("m_OpeningDefinition", BindingFlags.NonPublic | BindingFlags.Instance);
    }
}
