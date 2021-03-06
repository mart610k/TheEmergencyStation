using System;
using System.Collections.Generic;
using System.Text;

namespace TheEmergencyCentral
{
    public interface IPatient
    {
        /// <summary>
        /// The time required to solve the issue with the patient
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
        
        /// <summary>
        /// Sets the emergency Central the Patient will call
        /// </summary>
        /// <param name="emergencyCentral"></param>
        void SetEmergencyCentral(IEmergencyCentral emergencyCentral);

        /// <summary>
        /// Starts the patient acting on its own.
        /// </summary>
        public void Start();

        /// <summary>
        /// When the patient is acting on its own.
        /// </summary>
        public void Run();

        /// <summary>
        /// Joins the thread into the calling thread.
        /// </summary>
        public void Join();
    }
}
