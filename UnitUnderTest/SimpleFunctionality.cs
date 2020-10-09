namespace UnitUnderTest
{
    public class SimpleFunctionality : ISimpleFunctionality
    {
        int ISimpleFunctionality.GetSimpleLength()
        {
            return 23 + 42;
        }
    }
}
