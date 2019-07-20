using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = ("Story"))]

public class Story : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] String _storyText;
    [SerializeField] Story[] _nextStories;

    public String GetStoryState()
    {
        return _storyText;
    }

    public Story[] GetNextStory()
    {
        return _nextStories;
    }
}
