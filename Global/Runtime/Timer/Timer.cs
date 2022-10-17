using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MEC;

namespace Meta.Global
{

    public class Timer
    {

        private CoroutineHandle coroutineHandle;
        private float secs;
        private float interval;

        public Action<float> onTick = (float remainingSecs) => { };
        public Action onComplete = () => { };

        public Timer(float secs, float interval = 1f)
        {
            this.secs = secs;
            this.interval = interval;
        }

        public void Start()
        {
            Stop();
            float remainingSecs = secs;
            IEnumerator<float> CountdownRoutine()
            {
                while (remainingSecs > 0)
                {
                    onTick.Invoke(remainingSecs);
                    yield return Timing.WaitForSeconds(interval);
                    remainingSecs--;
                }
                onComplete.Invoke();
            }
            coroutineHandle = Timing.RunCoroutine(CountdownRoutine());
        }

        public void Stop()
        {
            if (coroutineHandle != null)
                Timing.KillCoroutines(coroutineHandle);
        }

    }

}