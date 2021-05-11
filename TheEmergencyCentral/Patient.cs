using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TheEmergencyCentral
{
    public class Patient : IPatient
    {
        public int TimeRequiredSeconds { get; private set; }

        public int PhoneNumber { get; private set; }

        public bool AwaitingCall => throw new NotImplementedException();

        private IEmergencyCentral emergencyCentral;

        public Thread myThread;

        private bool priorityRequired;

        private bool serviceReceived;

        public void CallAlarmCentral()
        {
            if (priorityRequired)
            {
                emergencyCentral.PriorityCall(this);
            }
            else
            {
                emergencyCentral.QueueNumber(this);
            }
        }

        public void ReceiveCall()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            CallAlarmCentral();
        }

        public void Join()
        {
            myThread.Join();
        }

        public void Start()
        {
            myThread = new Thread(() => Run());
            myThread.Start();
        }

        public void SetEmergencyCentral(IEmergencyCentral emergencyCentral)
        {
            this.emergencyCentral = emergencyCentral;
        }

        public Patient(int timeRequired, int phoneNumber, bool priorityRequired = false)
        {
            TimeRequiredSeconds = timeRequired;
            PhoneNumber = phoneNumber;
            this.priorityRequired = priorityRequired;
        }
    }
}
