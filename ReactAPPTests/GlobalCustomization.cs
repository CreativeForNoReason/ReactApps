using AutoFixture;
using AutoFixture.AutoMoq;
using ReactApp.Models;

namespace ReactAPPTests
{
    public class GlobalCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new AutoMoqCustomization())
                .Customize(new SupportMutableValueTypesCustomization()); // support for structs
        }
    }
}
