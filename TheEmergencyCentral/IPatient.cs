using System;
using System.Collections.Generic;
using System.Text;

namespace TheEmergencyCentral
{
    public interface IPatient
    {
        /// <summary>
        /// The time required to solve the issue with the patintient
        /// </summary>
        int TimeRequiredSeconds { get; }

        /// <summary>
        /// The Patients Phone Number
        /// </summary>
        int PhoneNumber { get; }

        /// <summary>
        /// If the patient is awaiting a call
        /// </summary>
        bool AwaitingCall { get; }

        /// <summary>
        /// Called Exeternally When patient is called
        /// </summary>
        void ReceiveCall();

        /// <summary>
        /// Calls the EmergencyCentral
        /// </summary>
        void CallAlarmCentral();
    }
}
