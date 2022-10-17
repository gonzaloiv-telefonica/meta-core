using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Meta.Global
{

    public class TimerSample : MonoBehaviour
    {

        [SerializeField] private float totalSecs = 10f;
        [SerializeField] private float tick = 1f;

        [SerializeField] private TextMeshProUGUI label;

        private void Start()
        {
            label.text = totalSecs.ToString();
            Timer timer = new Timer(totalSecs, tick);
            timer.onTick += remainingSecs => label.text = remainingSecs.ToString();
            timer.onComplete += () => label.text = "Countdown complete!";
            timer.Start();
        }

    }

}