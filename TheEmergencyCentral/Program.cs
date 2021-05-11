using System;
using System.Collections.Generic;

namespace TheEmergencyCentral
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPatient> patients = new List<IPatient>();
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            for (int i = 0; i < 100; i++)
            {
                IPatient patient = new Patient(0, i);
                patient.SetEmergencyCentral(emergencyCentral);
                patient.Start();
                patients.Add(patient);
                
            }
            foreach (IPatient item in patients)
            {
                item.Join();
            }


            Console.WriteLine(emergencyCentral.AmountOfPatientsInQueue());
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
