using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TheEmergencyCentral;

namespace TheEmergencyCentralTests
{
    class EmergencyCentralTests
    {
        [Test]
        public void AmountOfPatientsInQueue_DontReturnNIException()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();
            int test;
            Assert.DoesNotThrow(() => test = emergencyCentral.AmountOfPatientsInQueue());
        }

        [Test]
        public void AmountOfPatientsInQueue_ReturnsZero()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            Assert.AreEqual(0, emergencyCentral.AmountOfPatientsInQueue());
        }

        [Test]
        public void AmountOfPatientsInPriorityQueue_DontReturnNIException()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();
            int test;
            Assert.DoesNotThrow(() => test = emergencyCentral.AmountOfPatientsInPriorityQueue());
        }

        [Test]
        public void AmountOfPatientsInPriorityQueue_ReturnsZero()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            Assert.AreEqual(0, emergencyCentral.AmountOfPatientsInPriorityQueue());
        }

        [Test]
        public void QueueNumber_DontThrow()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.DoesNotThrow(() => emergencyCentral.QueueNumber(patient));
        }

        [Test]
        public void QueueNumber_ReturnsTrue()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.True(emergencyCentral.QueueNumber(patient));
        }

        [Test]
        public void QueueNumber_AddsPatientToQueue()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.QueueNumber(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInQueue());

        }

        [Test]
        public void QueueNumber_DoesNotAddPatientsPresent()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.QueueNumber(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInQueue());

            emergencyCentral.QueueNumber(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInQueue());
        }

        [Test]
        public void QueueNumber_ReturnsFalseIfPatientExists()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.QueueNumber(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInQueue());

            Assert.False(emergencyCentral.QueueNumber(patient));
        }

        //---------------------------------------------------------------------------------\\

        [Test]
        public void PriorityCall_DoesNotThrow()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.DoesNotThrow(() => emergencyCentral.PriorityCall(patient));
        }

        [Test]
        public void PriorityCall_ReturnsTrue()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.True(emergencyCentral.PriorityCall(patient));
        }

        [Test]
        public void PriorityCall_AddsPatientToQueue()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.PriorityCall(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInPriorityQueue());

        }

        [Test]
        public void PriorityCall_DoesNotAddPatientsPresent()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.PriorityCall(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInPriorityQueue());

            emergencyCentral.PriorityCall(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInPriorityQueue());
        }

        [Test]
        public void PriorityCall_ReturnsFalseIfPatientExists()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.PriorityCall(patient);

            Assert.AreEqual(1, emergencyCentral.AmountOfPatientsInPriorityQueue());

            Assert.False(emergencyCentral.PriorityCall(patient));
        }

        //---------------------------------------------------------------------------------\\

        [Test]
        public void QueueNumberForCallFromEmployee_DoesNotThrow()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.DoesNotThrow(() => emergencyCentral.QueueNumberForCallFromEmployee(patient));
        }

        [Test]
        public void QueueNumberForCallFromEmployee_PatientMustBeOnPatientsQueue()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.False(emergencyCentral.QueueNumberForCallFromEmployee(patient));
        }


        [Test]
        public void QueueNumberForCallFromEmployee_PatientIsOnPatientsQueue()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.QueueNumber(patient);

            Assert.True(emergencyCentral.QueueNumberForCallFromEmployee(patient));
        }

        //---------------------------------------------------------------------------------\\


        [Test]
        public void ElevateCallToDoctor_DoesNotThrow()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.DoesNotThrow(() => emergencyCentral.ElevateCallToDoctor(patient));
        }

        [Test]
        public void ElevateCallToDoctor_CallElevatedToDoctor()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            Assert.True(emergencyCentral.ElevateCallToDoctor(patient));
        }

        [Test]
        public void ElevateCallToDoctor_CallAlreadyElevatedToDoctor()
        {
            IEmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient patient = new Patient(0, 123456789);

            emergencyCentral.ElevateCallToDoctor(patient);

            Assert.False(emergencyCentral.ElevateCallToDoctor(patient));
        }

    }
}
