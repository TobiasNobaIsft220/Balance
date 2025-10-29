using UnityEditor;
using UnityEngine;

public class FindMissingScripts : EditorWindow
{
    [MenuItem("Tools/Buscar Scripts Faltantes en Escena")]
    public static void FindMissingScriptsInScene()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        int missingCount = 0;

        foreach (GameObject go in allObjects)
        {
            Component[] components = go.GetComponents<Component>();

            foreach (Component c in components)
            {
                if (c == null)
                {
                    Debug.LogWarning($"🚨 Script faltante en objeto: {go.name}", go);
                    missingCount++;
                }
            }
        }

        Debug.Log($"✅ Búsqueda completa: {missingCount} scripts faltantes encontrados.");
    }
}
