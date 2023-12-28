using System;
using System.Text;
using Unity.Profiling;
using UnityEngine;

// Based on online Unity Docs
public class MemoryUsage : MonoBehaviour
{
    String PrettyPrint(double i)
    {
        String u = "";
        if (i > 1024) { i /= 1024; u = "K"; }
        if (i > 1000) { i /= 1000; u = "M"; }
        // if ( i > 1000) { i /= 1000; u = "G";  } /* Uncomment to enable Gigabytes unit */

        return $"{Math.Round(i, 2)}{u}";
    }

    string _statsText;
    ProfilerRecorder _totalReservedMemoryRecorder;
    ProfilerRecorder _gcReservedMemoryRecorder;
    ProfilerRecorder _textureMemoryRecorder;
    ProfilerRecorder _meshMemoryRecorder;
    void OnEnable()
    {
        _totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
        _gcReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        _textureMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Texture Memory");
        _meshMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Mesh Memory");
    }
    void OnDisable()
    {
        _totalReservedMemoryRecorder.Dispose();
        _gcReservedMemoryRecorder.Dispose();
        _textureMemoryRecorder.Dispose();
        _meshMemoryRecorder.Dispose();
    }
    void FixedUpdate()
    {
        var sb = new StringBuilder(500);
        if (_meshMemoryRecorder.Valid) sb.AppendLine($"Mesh Used Memory: {PrettyPrint(_meshMemoryRecorder.LastValue)}");
        if (_gcReservedMemoryRecorder.Valid) sb.AppendLine($"GC Reserved Memory: {PrettyPrint(_gcReservedMemoryRecorder.LastValue)}");
        if (_textureMemoryRecorder.Valid) sb.AppendLine($"Texture: {PrettyPrint(_textureMemoryRecorder.LastValue)}");
        if (_totalReservedMemoryRecorder.Valid) sb.AppendLine($"Total Reserved Memory: {PrettyPrint(_totalReservedMemoryRecorder.LastValue)}");
        _statsText = sb.ToString();
    }
    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, 250, 70), _statsText);
    }
}
