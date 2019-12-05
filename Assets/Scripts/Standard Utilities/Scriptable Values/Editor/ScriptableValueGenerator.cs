#if UNITY_EDITOR

using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

/*
 * PROJECT_NAME
 * TEMPLATE_NAMESPACE
 * VALUE_CLASS_NAME
 * REFERENCE_CLASS_NAME
 * TYPE
 */

namespace StandardUtilities
{
    static class ScriptableValueGenerator
    {
        private const string TEMPLATE_FILE_EXTENSION = ".txt";

        // Generate all code for the project
        [MenuItem("My Project/Code Generation/Generate Scriptable Variables")]
        static void Generate()
        {
            GenerateNumericCode("StandardUtilities.ScriptableValues", "float");
            GenerateNumericCode("StandardUtilities.ScriptableValues", "int");
            GenerateNumericCode("StandardUtilities.ScriptableValues", "double");
            GenerateNumericCode("StandardUtilities.ScriptableValues", "Vector3");
            GenerateNumericCode("StandardUtilities.ScriptableValues", "Vector2");

            GenerateNonNumericCode("StandardUtilities.ScriptableValues", "Color");
            GenerateNonNumericCode("StandardUtilities.ScriptableValues", "string");
            GenerateNonNumericCode("StandardUtilities.ScriptableValues", "bool");            
        }

        private static void GenerateNumericCode(
            string TEMPLATE_NAME,
            string TYPE)
        {
            GenerateCode(TEMPLATE_NAME, TYPE, "SCRIPTABLE_VALUE_NUMERIC");
        }

        private static void GenerateNonNumericCode(
            string TEMPLATE_NAME,
            string TYPE)
        {
            GenerateCode(TEMPLATE_NAME, TYPE, "SCRIPTABLE_VALUE_NON_NUMERIC");
        }

        private static void GenerateCode(
            string TEMPLATE_NAME,
            string TYPE,
            string VARIABLE_FILE_NAME)
        {
            string TYPE_NAME = TYPE;
            TYPE_NAME = string.Format("{0}{1}", TYPE_NAME.First().ToString().ToUpper(), TYPE_NAME.Substring(1));

            string VALUE_CLASS_NAME = string.Format("{0}Variable", TYPE_NAME);
            string REFERENCE_CLASS_NAME = string.Format("{0}Reference", TYPE_NAME);

            string assetsDirPath = Application.dataPath;
            string basePath = string.Format("{0}/{1}", assetsDirPath, "Scripts/Standard Utilities/Scriptable Values");
            string templatesDirPath = Path.Combine(basePath, "Templates");

            const int VALUE_TEMPLATE = 0;
            const int REFERENCE_TEMPLATE = 1;
            const int EDITOR_REFERENCE_TEMPLATE = 2;

            string[] templates = new string[3];

            templates[VALUE_TEMPLATE] = File.ReadAllText(string.Format("{0}{1}", Path.Combine(templatesDirPath, VARIABLE_FILE_NAME), TEMPLATE_FILE_EXTENSION));
            templates[REFERENCE_TEMPLATE] = File.ReadAllText(string.Format("{0}{1}", Path.Combine(templatesDirPath, "SCRIPTABLE_REFERENCE"), TEMPLATE_FILE_EXTENSION));
            templates[EDITOR_REFERENCE_TEMPLATE] = File.ReadAllText(string.Format("{0}{1}", Path.Combine(templatesDirPath, "EDITOR_SCRIPTABLE_REFERENCE"), TEMPLATE_FILE_EXTENSION));

            string[] paths = new string[3];

            paths[VALUE_TEMPLATE] = string.Format("{0}/{1}.cs", basePath, VALUE_CLASS_NAME);
            paths[REFERENCE_TEMPLATE] = string.Format("{0}/{1}.cs", basePath, REFERENCE_CLASS_NAME);
            paths[EDITOR_REFERENCE_TEMPLATE] = string.Format("{0}/{1}/{2}.cs", basePath, "Editor", string.Format("{0}{1}", "Editor", REFERENCE_CLASS_NAME));

            for (int i = 0; i < templates.Length; i++)
            {
                string result = templates[i]
                .Replace("VALUE_CLASS_NAME", VALUE_CLASS_NAME)
                .Replace("REFERENCE_CLASS_NAME", REFERENCE_CLASS_NAME)
                .Replace("TEMPLATE_NAMESPACE", TEMPLATE_NAME)
                .Replace("TYPE", TYPE);

                File.WriteAllText(paths[i], result);
            }

            AssetDatabase.Refresh();
        }
    }
}
#endif