using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConversiationUIItem
{
    public enum ContentType
    {
        Message,
        MediaUrl
    }

    public ContentType Type;
    public string Content;
    public bool IsFromTwin;
}

public class SDKTestUI : MonoBehaviour
{
    public SDKTest Sdk;
    public float UiWidth;
    public float ToolbarButtonWidth;
    public float TextMessageHeight;
    public float TextBoxHeight;
    public float TalkButtonWidth;
    public List<ConversiationUIItem> Items;
    public string[] Cultures;
    private string currentTalkingString = "Parla";
    
    private void OnGUI()
    {
        // top left: status
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUI.Label(new Rect(
            Screen.width * 0.5f - UiWidth * 0.5f,
            10f,
            UiWidth * 0.5f,
            TextBoxHeight), Sdk.TwinDesc.MemoriName);
        if (Sdk.IsSessionOpen)
        {
            GUI.Label(new Rect(
                Screen.width * 0.5f - UiWidth * 0.5f,
                40f,
                UiWidth * 0.5f,
                TextBoxHeight), "Talking...");
        }
        // top right: language combobox, open or close conversation
        GUI.skin.label.alignment = TextAnchor.UpperRight;

        int langSelectedIndex = Array.IndexOf(Cultures, Sdk.Language);
        int newLangSelectedIndex = GUI.Toolbar(new Rect(
            Screen.width * 0.5f + UiWidth * 0.5f - ToolbarButtonWidth * 2f,
            10f,
            ToolbarButtonWidth * 2f,
            TextBoxHeight), langSelectedIndex, new[] { "Italiano", "English" });
        Sdk.Language = Cultures[newLangSelectedIndex];
        
        if(GUI.Button(new Rect(
            Screen.width * 0.5f + UiWidth * 0.5f - ToolbarButtonWidth,
            50f,
            ToolbarButtonWidth,
            TextBoxHeight), Sdk.IsSessionOpen ? "Close" : "Open"))
        {
            if(!Sdk.IsSessionOpen)
                Sdk.OpenSession("ciao");
            else
                Sdk.CloseCurrentSession();
        }
        // center: conversations (left twin, right user, from bottom to top)
        for (int i = Items.Count - 1; i >= 0; --i)
        {
            float currentItemYPos = Screen.height - TextMessageHeight - 20f - (i + 1) * TextMessageHeight;
            if(currentItemYPos < 90f)
                continue; // To not overlap with the status above
            if (Items[i].IsFromTwin)
            {
                if (Items[i].Type == ConversiationUIItem.ContentType.Message)
                {
                    GUI.skin.label.alignment = TextAnchor.UpperLeft;
                    GUI.Label(new Rect(
                        Screen.width * 0.5f - UiWidth * 0.5f,
                        currentItemYPos,
                        UiWidth * 0.5f,
                        TextMessageHeight), Items[i].Content);
                }
                else // MediaUrl
                {
                    if (GUI.Button(new Rect(
                            Screen.width * 0.5f - UiWidth * 0.5f,
                            currentItemYPos,
                            TalkButtonWidth * 2f,
                            TextMessageHeight), "Open Media"))
                    {
                        Application.OpenURL(Items[i].Content);
                    }
                }
            }
            else // from user
            {
                GUI.skin.label.alignment = TextAnchor.UpperRight;
                GUI.Label(new Rect(
                    Screen.width * 0.5f,
                    currentItemYPos,
                    UiWidth * 0.5f,
                    TextMessageHeight), Items[i].Content);
            }
        }

        if (Sdk.IsSessionOpen)
        {
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            // bottom: text field and button to send text, enable only if there is an active session
            currentTalkingString = GUI.TextArea(new Rect(
                Screen.width * 0.5f - UiWidth * 0.5f,
                Screen.height - TextBoxHeight - 10f,
                UiWidth - TalkButtonWidth,
                TextBoxHeight), currentTalkingString);
            if (GUI.Button(new Rect(
                    Screen.width * 0.5f + UiWidth * 0.5f - TalkButtonWidth,
                    Screen.height - TextBoxHeight - 10f,
                    TalkButtonWidth,
                    TextBoxHeight), "Invia"))
            {
                Sdk.SendRequest(currentTalkingString);
                Items.Insert(0, new ConversiationUIItem()
                {
                    Content = currentTalkingString,
                    IsFromTwin = false,
                    Type = ConversiationUIItem.ContentType.Message
                });
                currentTalkingString = "";
            }
        }
    }

    public void AddTwinMessage(string message)
    {
        Items.Insert(0, new ConversiationUIItem()
        {
            Content = message,
            IsFromTwin = true,
            Type = ConversiationUIItem.ContentType.Message
        });
        
    }
    
    public void AddTwinMedia(string url)
    {
        Items.Insert(0, new ConversiationUIItem()
        {
            Content = url,
            IsFromTwin = true,
            Type = ConversiationUIItem.ContentType.MediaUrl
        });
    }

}
