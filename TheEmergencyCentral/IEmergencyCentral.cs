using System;
using System.Collections.Generic;
using System.Text;

namespace TheEmergencyCentral
{
    public interface IEmergencyCentral
    {

        /// <summary>
        /// Queues the given number in the prirority List
        /// </summary>
        /// <param name="numberToQueue">The number calling</param>
        /// <returns>Result if the number was queued</returns>
        bool QueueNumber(int numberToQueue);


        /// <summary>
        /// Queues the number for an employee to call back to.
        /// </summary>
        /// <param name="numberToCall">The number to call</param>
        /// <returns>If the number have been sucessfully registered</returns>
        bool QueueNumberForCallFromEmployee(int numberToCall);

        /// <summary>
        /// When a number calls the Central on the priority Number
        /// </summary>
        /// <param name="numberCalling">number calling</param>
        /// <returns>if the call is received and queued</returns>
        bool PriorityCall(int numberCalling);

        
        

    }
}
