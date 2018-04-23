using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll
{
    private int mPinsHit;

    private bool mIsGutter;

    private int mFrameNumber;

    public int PinsHit
    {
        get
        {
            return mPinsHit;
        }
        private set
        {
            mPinsHit = value;
            IsGutter = (value > 0) ? false : true;
        }
    }

    public bool IsGutter
    {
        get
        {
            return mIsGutter;
        }
        private set
        {
            mIsGutter = value;
        }
    }

    public int FrameNumber
    {
        get
        {
            return mFrameNumber;
        }
        private set
        {
            mFrameNumber = value;
        }
    }

    public Roll(int frameNumber)
    {
        FrameNumber = frameNumber;
    }

    public void HitPins(int numPins)
    {
        PinsHit = numPins;
    }
}

