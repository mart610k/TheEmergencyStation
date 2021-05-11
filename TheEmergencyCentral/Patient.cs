using System;
using System.Collections.Generic;
using System.Text;

namespace TheEmergencyCentral
{
    public class Patient : IPatient
    {
        public int TimeRequiredSeconds { get; private set; }

        public int PhoneNumber { get; private set; }

        public bool AwaitingCall => throw new NotImplementedException();

        public void CallAlarmCentral()
        {
            throw new NotImplementedException();
        }

        public void ReceiveCall()
        {
            throw new NotImplementedException();
        }

        public Patient(int timeRequired, int phoneNumber)
        {
            TimeRequiredSeconds = timeRequired;
            PhoneNumber = phoneNumber;
        }
    }
}
