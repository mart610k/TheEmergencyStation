using System;
using System.Collections.Generic;
using System.Text;

namespace TheEmergencyCentral
{
    public interface IEmergencyCentral
    {
        /// <summary>
        /// Gets the amount of patients in the queue.
        /// </summary>
        int AmountOfPatientsInQueue();

        /// <summary>
        /// Gets the amount of patients in Priority queue.
        /// </summary>
        int AmountOfPatientsInPriorityQueue();

        /// <summary>
        /// Queues the given number in the prirority List
        /// </summary>
        /// <param name="numberToQueue">The number calling</param>
        /// <returns>Result if the number was queued</returns>
        bool QueueNumber(IPatient numberToQueue);

        /// <summary>
        /// Queues the number for an employee to call back to.
        /// </summary>
        /// <param name="numberToCall">The number to call</param>
        /// <returns>If the number have been sucessfully registered</returns>
        bool QueueNumberForCallFromEmployee(IPatient numberToCall);

        /// <summary>
        /// When a number calls the Central on the priority Number
        /// </summary>
        /// <param name="numberCalling">number calling</param>
        /// <returns>if the call is received and queued</returns>
        bool PriorityCall(IPatient numberCalling);

        /// <summary>
        /// Elevates the call to a doctor.
        /// </summary>
        /// <param name="patient">patient To elevate</param>
        /// <returns>Call have successfully elevated to Doctor</returns>
        bool ElevateCallToDoctor(IPatient patient);

        /// <summary>
        /// Runs the Emergency Center on its own thread.
        /// </summary>
        void Run();

        /// <summary>
        /// Starts the Emergency Center to start handling different requests.
        /// </summary>
        void Start();


    }
}
