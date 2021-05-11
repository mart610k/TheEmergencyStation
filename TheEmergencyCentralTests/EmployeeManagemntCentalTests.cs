using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TheEmergencyCentral;

namespace TheEmergencyCentralTests
{
    class EmployeeManagemntCentalTests
    {
        [Test]
        public void GetHighestPrioityCall_DoesNotThrow()
        {
            IEmployeeManagement emergencyCentral = new EmergencyCentral();

            Assert.DoesNotThrow(() => emergencyCentral.GetHighestPrioityCall());
        }

        [Test]
        public void GetHighestPrioityCall_ReturnsNullOnEmptyList()
        {
            IEmployeeManagement emergencyCentral = new EmergencyCentral();

            Assert.Null(emergencyCentral.GetHighestPrioityCall());
        }

        [Test]
        public void GetHighestPrioityCall_ReturnsHighPriorityCall()
        {
            EmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient expected = new Patient(0, 84653515);

            // Casting here to use the Interface as a guide to send the request in.(Also guarentees that EmergencyCentral is of type IEmergencyCentral)
            ((IEmergencyCentral)emergencyCentral).PriorityCall(expected);

            IPatient actual = ((IEmployeeManagement)emergencyCentral).GetHighestPrioityCall();

            Assert.AreEqual(expected.TimeRequiredSeconds, actual.TimeRequiredSeconds);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
        }

        [Test]
        public void GetHighestPrioityCall_ReturnsHighPriorityAndRemovesPatient()
        {
            EmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient expected = new Patient(0, 84653515);

            // Casting here to use the Interface as a guide to send the request in.(Also guarentees that EmergencyCentral is of type IEmergencyCentral)
            ((IEmergencyCentral)emergencyCentral).PriorityCall(expected);

            IPatient actual = ((IEmployeeManagement)emergencyCentral).GetHighestPrioityCall();

            Assert.AreEqual(expected.TimeRequiredSeconds, actual.TimeRequiredSeconds);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);

            Assert.Null(((IEmployeeManagement)emergencyCentral).GetHighestPrioityCall());
        }

        [Test]
        public void GetHighestPrioityCall_DontReturnNullOnNormalCallList()
        {
            EmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient expected = new Patient(0, 84653515);

            // Casting here to use the Interface as a guide to send the request in.(Also guarentees that EmergencyCentral is of type IEmergencyCentral)
            ((IEmergencyCentral)emergencyCentral).QueueNumber(expected);

            IPatient actual = ((IEmployeeManagement)emergencyCentral).GetHighestPrioityCall();

            Assert.NotNull(actual);
            Assert.AreEqual(expected.TimeRequiredSeconds, actual.TimeRequiredSeconds);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
        }

        [Test]
        public void GetHighestPrioityCall_ReturnsNormalPriorityAndRemovesPatient()
        {
            EmergencyCentral emergencyCentral = new EmergencyCentral();

            IPatient expected = new Patient(0, 84653515);

            // Casting here to use the Interface as a guide to send the request in.(Also guarentees that EmergencyCentral is of type IEmergencyCentral)
            ((IEmergencyCentral)emergencyCentral).QueueNumber(expected);

            IPatient actual = ((IEmployeeManagement)emergencyCentral).GetHighestPrioityCall();

            Assert.AreEqual(expected.TimeRequiredSeconds, actual.TimeRequiredSeconds);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);

            Assert.Null(((IEmployeeManagement)emergencyCentral).GetHighestPrioityCall());
        }

        //---------------------------------------------------------------------------------\\

        [Test]
        public void GetDoctorCall_DoesNotThrow()
        {
            IEmployeeManagement emergencyCentral = new EmergencyCentral();

            Assert.DoesNotThrow(() => emergencyCentral.GetDoctorCall());
        }

        [Test]
        public void GetDoctorCall_GetsPatientAwaiting()
        {
            IEmployeeManagement emergencyCentral = new EmergencyCentral();

            IPatient expected = new Patient(0, 84653515);

            // Casting here to use the Interface as a guide to send the request in.(Also guarentees that EmergencyCentral is of type IEmergencyCentral)
            ((IEmergencyCentral)emergencyCentral).ElevateCallToDoctor(expected);

            IPatient actual = emergencyCentral.GetDoctorCall();

            Assert.AreEqual(expected.TimeRequiredSeconds, actual.TimeRequiredSeconds);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
        }

        [Test]
        public void GetDoctorCall_RemovesPatientWaitingOnCall()
        {
            IEmployeeManagement emergencyCentral = new EmergencyCentral();

            IPatient expected = new Patient(0, 84653515);

            // Casting here to use the Interface as a guide to send the request in.(Also guarentees that EmergencyCentral is of type IEmergencyCentral)
            ((IEmergencyCentral)emergencyCentral).ElevateCallToDoctor(expected);

            IPatient actual = emergencyCentral.GetDoctorCall();

            Assert.AreEqual(expected.TimeRequiredSeconds, actual.TimeRequiredSeconds);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);

            Assert.Null(emergencyCentral.GetDoctorCall());
        }
    }
}
