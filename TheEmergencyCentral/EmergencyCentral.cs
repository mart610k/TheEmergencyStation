using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TheEmergencyCentral
{
    public class EmergencyCentral : IEmergencyCentral, IEmployeeManagement
    {

        private Thread emergencyCentralThread;

        private List<IPatient> patientsInQueue = new List<IPatient>();

        private List<IPatient> priorityPatientsInQueue = new List<IPatient>();

        private List<IPatient> patientsAwaitingCallFromEmployee = new List<IPatient>();

        private List<IPatient> patientsAwaitingDoctor = new List<IPatient>();

        private readonly object patientsInQueueLock = new object();

        private readonly object priorityPatientsInQueueLock = new object();

        private readonly object patientsAwaitingCallFromEmployeeLock = new object();

        private readonly object patientsAwaitingDoctorLock = new object();


        public int AmountOfPatientsInQueue()
        {
            return patientsInQueue.Count;
            
        }

        public int AmountOfPatientsInPriorityQueue()
        {
            return priorityPatientsInQueue.Count;
        }

       
        public EmergencyCentral()
        {
            emergencyCentralThread = new Thread(() => Run());
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

        public IPatient GetHighestPrioityCall()
        {
            IPatient patient = null;
            lock (priorityPatientsInQueueLock)
            {
                if (0 < priorityPatientsInQueue.Count)
                {
                    patient = priorityPatientsInQueue[0];
                    priorityPatientsInQueue.RemoveAt(0);
                }
            }
            if(patient == null)
            {
                lock (patientsInQueueLock)
                {
                    if(0 < patientsInQueue.Count)
                    {
                        patient = patientsInQueue[0];
                        patientsInQueue.RemoveAt(0);
                    }
                }
            }
            return patient;
        }

        public IPatient GetDoctorCall()
        {
            IPatient patient = null;

            lock (patientsAwaitingDoctorLock)
            {
                if(0 < patientsAwaitingDoctor.Count)
                {
                    patient = patientsAwaitingDoctor[0];
                    patientsAwaitingDoctor.RemoveAt(0);
                }
            }
            return patient;
        }
    }
}
