using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField]QuestionModel questionModel;

    public Word GetWord(int level)
    {
        return questionModel.GetRandomLevelWord(level);
    }
}