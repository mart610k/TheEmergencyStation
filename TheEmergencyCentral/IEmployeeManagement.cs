using System;
using System.Collections.Generic;
using System.Text;

namespace TheEmergencyCentral
{
    public interface IEmployeeManagement
    {
        /// <summary>
        /// Gets the highest priority call from the prioritised lists
        /// </summary>
        /// <returns>The highest priority call or null if no call</returns>
        IPatient GetHighestPrioityCall();

        /// <summary>
        /// Gets a doctor call, returns null if no Doctor call is queued
        /// </summary>
        /// <returns>A patient awaiting a doctor, or null if no patients are awaiting a doctor</returns>
        IPatient GetDoctorCall();



    }
}
