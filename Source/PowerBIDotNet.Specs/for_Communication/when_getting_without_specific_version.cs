using System.Net;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace PowerBIDotNet.Specs.for_Communication
{
    public class when_getting_without_specific_version : given.a_communication_instance
    {
        static Token token = "My access token";
        static string action = "My action";
        static string version = "1.0";

        static string url_used;

        Establish context = () =>
        {
            Mock<WebRequest> web_request_mock = new Mock<WebRequest>();
            Mock<WebResponse> web_response_mock = new Mock<WebResponse>();
            web_request_mock.Setup(w => w.GetResponse()).Returns(web_response_mock.Object);

            web_request_factory_mock.Setup(w => w.CreateRequestThatIsKeptAlive(Moq.It.IsAny<string>())).Returns((string url) =>
                {
                    url_used = url;
                    return web_request_mock.Object;
                });
        };
        
        Because of = () => communication.Get<object>(token, action);

        It should_get = () => { };
        //url_used.ShouldEqual(string.Format(Communication.UrlString,version, action)); 

        
    }
}
