using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Frame
    {
        private Roll[] mRollList;
        private int mFrameScore;
        private bool mIsSpare;
        private bool mIsStrike;

        private int currentRoll;

        public int FrameScore
        {
            get
            {

                return mFrameScore;

            }
            set
            {
                mFrameScore = value;
            }
        }

        public int FrameNumber
        {
            get; set;
        }

        public bool IsSpare
        {
            get
            {
                return mIsSpare;
            }
            set
            {
                mIsSpare = value;
            }
        }

        public bool IsStrike
        {
            get
            {
                return mIsStrike;
            }
            set
            {
                mIsStrike = value;
            }
        }

        public int CurrentRoll
        {
            get
            {
                return currentRoll;
            }
            private set
            {
                currentRoll = value;
            }
        }
        public Frame(int frameNumber)
        {
            mRollList = new Roll[2];
            for (int i = 0; i < 2; i++)
            {
                mRollList[i] = new Roll(FrameNumber);
            }
            FrameNumber = frameNumber;
            CurrentRoll = 0;
        }

        public void Roll(int pinNumbers)
        {
            mRollList[CurrentRoll].HitPins(pinNumbers);

            if (CurrentRoll == 0)
            {
                DetermineStrike();
                if (IsStrike)
                {
                    CurrentRoll += 2;
                }
                else
                {
                    currentRoll++;
                }
            }
            else
            {
                DetermineSpare();
                CurrentRoll++;
            }
            CalculateRollTotal();

        }

        private void CalculateRollTotal()
        {
            int score = 0;
            for (int i = 0; i < 2; i++)
            {
                score += mRollList[i].PinsHit;
            }

            FrameScore = score;
        }

        public void UpdateScore(int previousFrameScore, int bonusPoint = 0)
        {
            int rollTotal = FrameScore;
            FrameScore = rollTotal + previousFrameScore + bonusPoint;
        }

        public bool IsRollGutter(int rollNumber)
        {
            return mRollList[rollNumber].IsGutter;
        }


        private void DetermineStrike()
        {
            IsStrike = mRollList[0].PinsHit == 10 ? true : false;
        }

        private void DetermineSpare()
        {
            IsSpare = (mRollList[0].PinsHit + mRollList[1].PinsHit) == 10 ?
                true : false;
        }
    }

