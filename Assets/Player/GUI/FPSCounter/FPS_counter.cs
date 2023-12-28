using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
	public Text Text;

	void Update()
	{
		int FrameRate = (int)Mathf.Round(1f / Time.unscaledDeltaTime);
		Text.text = FrameRate.ToString();
	}
}