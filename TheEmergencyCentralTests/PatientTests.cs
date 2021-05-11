using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TheEmergencyCentral;

namespace TheEmergencyCentralTests
{
    class PatientTests
    {
        [Test]
        public void CallAlarmCentral_CallsAlarmCentral()
        {
            using (AutoMock mock = AutoMock.GetStrict())
            {
                IPatient patient = new Patient(0, 4124212);

                Mock<IEmergencyCentral> emergencyCentral = new Mock<IEmergencyCentral>();
                emergencyCentral.Setup(x => x.QueueNumber(patient))
                    .Returns(true);

                patient.SetEmergencyCentral(emergencyCentral.Object);

                patient.CallAlarmCentral();

                emergencyCentral.Verify(x => x.QueueNumber(patient), Times.Once);
            }
        }

        [Test]
        public void CallAlarmCentral_CallsPriorityNumberWhenPriority()
        {
            IPatient patient = new Patient(0, 4124212, true);

            Mock<IEmergencyCentral> emergencyCentral = new Mock<IEmergencyCentral>();
            emergencyCentral.Setup(x => x.PriorityCall(patient))
                .Returns(true);

            patient.SetEmergencyCentral(emergencyCentral.Object);

            patient.CallAlarmCentral();

            emergencyCentral.Verify(x => x.PriorityCall(patient), Times.Once);
        }

    }
}
