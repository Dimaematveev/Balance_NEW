namespace BalanceMain
{
    public sealed class NameAndIdTable
    {

        public object ID { get; }
        public string Name { get; }
        public NameAndIdTable(object id, string name)
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
