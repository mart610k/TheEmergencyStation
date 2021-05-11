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

        private Thread myThread;

        private bool priorityRequired;

        Random random;


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
            random = new Random();
            Thread.Sleep(random.Next(1000, 8000));

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
