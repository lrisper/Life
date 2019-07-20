using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoryManager : MonoBehaviour
{
    [SerializeField] Story _StartingStory;
    [SerializeField] Text _StoryText;

    Story story;

    // Start is called before the first frame update
    void Start()
    {
        story = _StartingStory;
        _StoryText.text = story.GetStoryState();
    }

    // Update is called once per frame
    void Update()
    {
        ManageStory();
    }

    private void ManageStory()
    {
        var nextStory = story.GetNextStory();

        for (int index = 0; index < nextStory.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                story = nextStory[index];
            }
        }
        _StoryText.text = story.GetStoryState();
    }
}
