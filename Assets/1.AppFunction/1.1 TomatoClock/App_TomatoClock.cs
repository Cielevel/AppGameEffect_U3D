using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AssetKits.ParticleImage;

namespace App.TomatoClock
{
    public class App_TomatoClock : MonoBehaviour
    {
        [SerializeField] private TMP_Text text_Counter;

        [SerializeField] private ParticleImage fx_onTimerEnd;

        private string Timer
        {
            get
            {
                if (timer_rest <= 0)
                    StopTimer();
                return FormattingTimer(timer_rest);
            }
        }
        private int timer_rest = 10;
        private int timer_Recordlast;
        private bool isTimerStarted = false;

        private const int SECONDS_PER_MINUTE = 60;

        #region Test on start
        private void Start()
        {
            StartTimer();
        }
        #endregion

        private float oneSecond = 0;
        private void Update()
        {
            if (isTimerStarted)
            {
                oneSecond += Time.deltaTime;
                if (oneSecond >= 1)
                {
                    oneSecond = 0;
                    timer_rest -= 1;
                    TimerShowOnUI();
                }
            }
        }

        private void SetTimer(int minutes, int seconds)
        {

        }

        private void StartTimer()
        {
            isTimerStarted = true;
        }

        private void StopTimer()
        {
            isTimerStarted = false;
            fx_onTimerEnd.Play();
        }

        private void TimerShowOnUI()
        {
            text_Counter.text = Timer;
        }

        private string FormattingTimer(int timer)
        {
            int minutes = timer / 60;
            int seconds = timer % 60;

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}