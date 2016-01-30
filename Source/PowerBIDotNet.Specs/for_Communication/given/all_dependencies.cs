using Machine.Specifications;
using Moq;

namespace PowerBIDotNet.Specs.for_Communication.given
{
    public class all_dependencies
    {
        protected static Mock<IWebRequestFactory> web_request_factory_mock;
        protected static Mock<ISerializer> serializer_mock;

        Establish context = () =>
        {
            web_request_factory_mock = new Mock<IWebRequestFactory>();
            serializer_mock = new Mock<ISerializer>();
        };
    }
}