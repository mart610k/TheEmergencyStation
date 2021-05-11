using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TheEmergencyCentral
{
    public class EmergencyCentral : IEmergencyCentral
    {

        Thread EmergencyCentralThread;

        public int AmountOfPatientsInQueue()
        {
            return patientsInQueue.Count;
            
        }

        public int AmountOfPatientsInPriorityQueue()
        {
            return priorityPatientsInQueue.Count;
        }

        List<IPatient> patientsInQueue = new List<IPatient>();

        List<IPatient> priorityPatientsInQueue = new List<IPatient>();

        List<IPatient> patientsAwaitingCallFromEmployee = new List<IPatient>();

        List<IPatient> patientsAwaitingDoctor = new List<IPatient>();

        private readonly object patientsInQueueLock = new object();

        private readonly object priorityPatientsInQueueLock = new object();

        private readonly object patientsAwaitingCallFromEmployeeLock = new object();

        private readonly object patientsAwaitingDoctorLock = new object();

        public EmergencyCentral()
        {
            EmergencyCentralThread = new Thread(() => Run());
        }
        
        public bool ElevateCallToDoctor(IPatient patient)
        {
            bool result = false;
            lock (patientsAwaitingDoctorLock)
            {
                if(patientsAwaitingDoctor.FindIndex(patientNeedsDoc => patientNeedsDoc.PhoneNumber == patient.PhoneNumber) == -1)
                {
                    patientsAwaitingDoctor.Add(patient);
                    result = true;
                }
            }
            return result;
        }

        public bool PriorityCall(IPatient numberCalling)
        {
            bool result = false;
            lock (priorityPatientsInQueueLock)
            {
                if (priorityPatientsInQueue.FindIndex(patient => patient.PhoneNumber == numberCalling.PhoneNumber) == -1)
                {
                    priorityPatientsInQueue.Add(numberCalling);
                    result = true;
                }
            }
            return result;
        }

        public bool QueueNumber(IPatient numberToQueue)
        {
            bool result = false;
            lock (patientsInQueueLock)
            {
                if(patientsInQueue.FindIndex(patient => patient.PhoneNumber == numberToQueue.PhoneNumber) == -1)
                {
                    patientsInQueue.Add(numberToQueue);
                    result = true;
                }
            }
            return result;
        }

        public bool QueueNumberForCallFromEmployee(IPatient numberToCall)
        {
            bool result = false;
            lock (patientsInQueueLock)
            {
                if (patientsInQueue.FindIndex(patient => patient.PhoneNumber == numberToCall.PhoneNumber) != -1)
                {
                    //TODO May cause a race condititon... lock within a lock...
                    lock (patientsAwaitingCallFromEmployeeLock)
                    {
                        patientsAwaitingCallFromEmployee.Add(numberToCall);
                        result = true;
                    }
                }
            }
            return result;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }


        public void Start() 
        {
            throw new NotImplementedException();
        }
    }
}
