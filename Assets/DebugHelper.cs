using UnityEngine;

public class DebugHelper : MonoBehaviour
{
    public void Log(string message)
    {
        Debug.Log(message);
    }

    public void LogName(Collider col)
    {
        Debug.Log(col.gameObject.name);
    }
}
