using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bowling : MonoBehaviour
{
    //private List<Frame> frames;
    //[SerializeField]
    //private int totalScore { get; set; }

    
    //void Start()
    //{

    //    //init score to 0 for start of game
    //    totalScore = 0;
    //    //init array list to be a list of 12 total frames
    //    frames = new List<Frame>();
    //}
    ///// <summary>
    ///// Call on every end_of_frame
    ///// Account for frame's 0-10, 10+ frame(s) have unique scoring and calculated separately
    ///// Update's totalScore
    ///// </summary>
    //public void calculateScore()
    //{
    //    foreach (Frame f in frames)
    //    {

    //    }
    //}
    //private void addFrame(Frame f)
    //{
    //    frames.Add(f);
    //}
    ///// <summary>
    ///// A spare has a retrospective update of score
    ///// Spare Logic: The subsequent roll (singular) + 10 is added to the
    ///// previous frame's score to become currentFrame's (the frame in which scored the spare) total Score
    ///// </summary>
    ///// <param name="f"></param>
    ///// <returns></returns>
    //private int spareUpdate(int frameWithSpareIndex, int subsequentRollFrame)
    //{
    //    Frame spare_frame = frames.ElementAt(frameWithSpareIndex);
    //    int incrementBy = frames.ElementAt(subsequentRollFrame).getFrameScore();
    //    //set spare_frame to current Total Score which is total score of previous frame 
    //    //will need fursther editing / testing because previous frame could be empty due to strike / spare too
    //    //totalScore should only update when there is a non-variable'd # to be read... (ie already calculated and already influenced by strike / spare)
    //    spare_frame.setFrameScore(totalScore);
    //    spare_frame.incrementFrameScore(incrementBy);
    //    return spare_frame.getFrameScore();

    //}
    //private int strikeUpdate(Frame f)
    //{
    //    return 0;
    //}
    //public void startFirstFrame()
    //{
    //    Frame start = new Frame(0);//0th frame == first frame DUH!
    //    addFrame(start);            //put the beginning frame in list
    //}
}
