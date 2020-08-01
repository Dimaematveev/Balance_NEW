namespace BalanceMain
{
    public sealed class NameAndIdTableBL
    {

        public object ID { get; }
        public string Name { get; }
        public NameAndIdTableBL(object id, string name)
        {
            ID = id;
            Name = name;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
