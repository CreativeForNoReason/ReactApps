using AutoFixture;
using AutoFixture.Xunit2;

namespace ReactAPPTests.Helpers
{
    public sealed class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() =>
        {
            return new Fixture().Customize(new GlobalCustomization());
        })
        {
        }
    }
}
