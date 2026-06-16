using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GeminiManager : MonoBehaviour
{
    public TMP_InputField questionInput;
    public TMP_Text answerText;

    public string currentDinosaur;

    [TextArea]
    public string apiKey;

    public void AskAI()
    {
        StartCoroutine(SendToGemini());
    }

    IEnumerator SendToGemini()
    {
        answerText.text = "Thinking...";

        string prompt =
            "You are a dinosaur expert. Answer in under 30 words.\n" +
            "Current dinosaur: " + PlacementManager.CurrentDinosaur + "\n" +
            "Question: " + questionInput.text;

        string jsonBody =
            "{\"contents\":[{\"parts\":[{\"text\":\"" +
            prompt.Replace("\"", "\\\"") +
            "\"}]}]}";

        string url =
            "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key="
            + apiKey;

        UnityWebRequest request = new UnityWebRequest(url, "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            answerText.text = "Error: " + request.error;
        }
        else
        {
            string json = request.downloadHandler.text;

            GeminiResponse response =
                JsonUtility.FromJson<GeminiResponse>(json);

            answerText.text =
                response.candidates[0].content.parts[0].text;
        }
    }
    [System.Serializable]
    public class GeminiResponse
    {
        public Candidate[] candidates;
    }

    [System.Serializable]
    public class Candidate
    {
        public Content content;
    }

    [System.Serializable]
    public class Content
    {
        public Part[] parts;
    }

    [System.Serializable]
    public class Part
    {
        public string text;
    }
}