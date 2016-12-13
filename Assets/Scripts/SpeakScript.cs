using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class SpeakScript : MonoBehaviour {

	public static void Speak(string talk_text)
	{
		Process process = new Process();
		process.StartInfo.FileName="say";
		process.StartInfo.Arguments = talk_text;
		process.StartInfo.RedirectStandardError=true;
		process.StartInfo.RedirectStandardOutput=true;
		process.StartInfo.CreateNoWindow=true;
		process.StartInfo.WorkingDirectory=Application.dataPath+"/..";
		process.StartInfo.UseShellExecute=false;
		process.Start();
	}

}
