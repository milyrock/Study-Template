using System.Runtime.InteropServices.ObjectiveC;
using Xunit;
using Study.LabWork1.Features.Task2;
using Assert = Xunit.Assert;

namespace Study.LabWork1.Tests
{
    public class MockUser : User
    {
        public string? LastMessage { get; set; }

        public MockUser(Mediator mediator, string name) : base(mediator, name) { }

        public override void Notify(string message)
        {
            LastMessage = message;
        }

        public override void Send(string message) => _mediator.Send(message,  this);
    }

    public class MediatorTests
    {
        [Fact]
        public void Send_DeliveredToUser1()
        {
            var mediator = new ConcreteMediator();
            var user1 = new MockUser(mediator, "u1");
            var user2 = new MockUser(mediator, "u2");
            mediator.user1 = user1;
            mediator.user2 = user2;
            const string message = "hello from u1!";

            user1.Send(message);

            Assert.Equal(message, user2.LastMessage);
            Assert.Null(user1.LastMessage);
        }

        [Fact]
        public void Send_DeliveredToUser2()
        {
            var mediator = new ConcreteMediator();
            var user1 = new MockUser(mediator, "u1");
            var user2 = new MockUser(mediator, "u2");
            mediator.user1 = user1;
            mediator.user2 = user2;
            const string message = "hello from u2!";

            user2.Send(message);

            Assert.Equal(message, user1.LastMessage);
            Assert.Null(user2.LastMessage);
        }

    }
}