using Machine.Specifications;

namespace PowerBIDotNet.Specs.for_Communication.given
{
    public class a_communication_instance : all_dependencies
    {
        protected static Communication communication;

        Establish context = () => communication = new Communication(web_request_factory_mock.Object, serializer_mock.Object);
    }
}
